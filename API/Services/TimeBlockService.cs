using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class TimeBlockService : ITimeBlockService
{
    private readonly ILoggerService _logger;
    private readonly ITimeBlockDAL _timeBlockDAL;
    private readonly ISubjectDAL _subjectDAL;
    private readonly IMapper _mapper;

    public TimeBlockService(
        ILoggerService logger,
        ITimeBlockDAL timeBlockDAL,
        ISubjectDAL subjectDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _timeBlockDAL = timeBlockDAL;
        _subjectDAL = subjectDAL;
        _mapper = mapper;
    }

    public async Task<TimeBlockTableRowDTO> Create(TimeBlockForCreationDTO timeBlockDTO)
    {
        if (timeBlockDTO.SubjectId == Guid.Empty) timeBlockDTO.SubjectId = null;
        TimeBlock timeBlock = _mapper.Map<TimeBlock>(timeBlockDTO);
        await _timeBlockDAL.Create(timeBlock);
        return await RetrieveForTable(timeBlock.Id);
    }

    public async Task<TimeBlockTableRowDTO> Update(Guid id, TimeBlockForUpdateDTO timeBlockDTO)
    {
        if (timeBlockDTO.SubjectId == Guid.Empty) timeBlockDTO.SubjectId = null;
        TimeBlock timeBlock = await GetRecordAndCheckExistence(id);

        // Update blockName with Subject name
        if (timeBlockDTO.SubjectId != null)
        {
            Subject subject = await _subjectDAL.Retrieve((Guid)timeBlockDTO.SubjectId, trackChanges: false);
            timeBlockDTO.BlockName = subject.Name;
        }

        _mapper.Map(timeBlockDTO, timeBlock);
        await _timeBlockDAL.Update(timeBlock);
        return await RetrieveForTable(timeBlock.Id);
    }

    public async Task Delete(Guid id)
    {
        TimeBlock timeBlock = await GetRecordAndCheckExistence(id);
        await _timeBlockDAL.Delete(timeBlock);
    }

    public async Task<TimeBlockDTO?> Retrieve(Guid id) => _mapper.Map<TimeBlockDTO>(await _timeBlockDAL.Retrieve(id));

    public async Task<List<TimeBlockTableRowDTO>> RetrieveAll(Guid gradeId, Guid teacherId) =>
        _mapper.Map<List<TimeBlockTableRowDTO>>(await _timeBlockDAL.RetrieveAll(gradeId, teacherId));

    private async Task<TimeBlock> GetRecordAndCheckExistence(Guid id)
    {
        TimeBlock timeBlock = await _timeBlockDAL.Retrieve(id);
        if (timeBlock is null)
            throw new EntityNotFoundException();
        return timeBlock;
    }

    private async Task<TimeBlockTableRowDTO?> RetrieveForTable(Guid id)
    {
        if (id == Guid.Empty) return null;
        var rows = await _timeBlockDAL.RetrieveForMainTable(id);
        if (rows == null || rows.Count == 0) return null;
        return _mapper.Map<TimeBlockTableRowDTO>(rows.FirstOrDefault());
    }

    public async Task CreateAllWeekTimeBlocksBase(Guid gradeId)
    {
        DateTime now = DateTime.Now;
        var timeBlockDayList = new List<TimeBlock>() {
            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Línea", Start = new TimeSpan(8, 30, 0), End = new TimeSpan(9, 0, 0) },

            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Desayuno", Start = new TimeSpan(9, 0, 0), End = new TimeSpan(9, 15, 0) },

            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Currículum Montessori", Start = new TimeSpan(9, 15, 0), End = new TimeSpan(12, 30, 0) },

            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Recreo", Start = new TimeSpan(12, 30, 0), End = new TimeSpan(13, 0, 0) },

            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Almuerzo", Start = new TimeSpan(13, 0, 0), End = new TimeSpan(13, 30, 0) },

            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Recreo", Start = new TimeSpan(13, 30, 0), End = new TimeSpan(14, 0, 0) },

            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Especialista 1", Start = new TimeSpan(14, 0, 0), End = new TimeSpan(15, 0, 0) },

            new TimeBlock() { Year = now.Year, Day = 1, IsRecess = true, GradeId = gradeId,
                BlockName = "Especialista 2", Start = new TimeSpan(15, 0, 0), End = new TimeSpan(16, 30, 0) },
        };

        for (byte day = 1; day <= 5; day++)
            foreach (var block in timeBlockDayList)
            {
                block.Day = day;
                await _timeBlockDAL.Create(new TimeBlock()
                {
                    GradeId = gradeId,
                    Year = block.Year,
                    Day = block.Day,
                    Start = block.Start,
                    End = block.End,
                    IsRecess = block.IsRecess,
                    BlockName = block.BlockName,
                });
            }
    }

}