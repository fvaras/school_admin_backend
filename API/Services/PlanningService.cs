using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class PlanningService : IPlanningService
{
    private readonly ILoggerService _logger;
    private readonly IPlanningDAL _planningDAL;
    private readonly ITimeBlockDAL _timeBlockDAL;
    private readonly IPlanningTimeBlockDAL _planningTimeBlockDAL;
    private readonly IMapper _mapper;

    public PlanningService(
        ILoggerService logger,
        IPlanningDAL planningDAL,
        ITimeBlockDAL timeBlockDAL,
        IPlanningTimeBlockDAL planningTimeBlockDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _planningDAL = planningDAL;
        _timeBlockDAL = timeBlockDAL;
        _planningTimeBlockDAL = planningTimeBlockDAL;
        _mapper = mapper;
    }

    public async Task<PlanningTableRowDTO> Create(PlanningForCreationDTO planningDTO)
    {
        Planning planning = _mapper.Map<Planning>(planningDTO);
        await _planningDAL.Create(planning);
        return await RetrieveForTable(planning.Id);
    }

    public async Task<PlanningTableRowDTO> Update(Guid id, PlanningForUpdateDTO planningDTO)
    {
        Planning planning = await GetRecordAndCheckExistence(id);
        _mapper.Map(planningDTO, planning);
        await _planningDAL.Update(planning);
        return await RetrieveForTable(planning.Id);
    }

    public async Task<PlanningTableRowDTO> UpdateWithTimeBlocks(Guid id, PlanningWithTimeBlocksForUpdateDTO planningDTO)
    {
        Planning planning = null;
        planning = await GetRecordWithTimeBlocksAndCheckExistence(id);
        _mapper.Map(planningDTO as PlanningForUpdateDTO, planning);
        await _planningDAL.Update(planning);

        var timeBlockPlanning = (await _planningTimeBlockDAL.GetPlanningTimeBlocks(timeBlockId: planningDTO.TimeBlockId, date: planningDTO.Date.Date)).FirstOrDefault();

        if (timeBlockPlanning != null)
        {
            if (planningDTO.Id == Guid.Empty)
                planning.PlanningTimeBlocks.Remove(timeBlockPlanning);
            else if (planningDTO.Id != timeBlockPlanning.PlanningId)
                timeBlockPlanning.PlanningId = planning.Id;
        }
        else if (planningDTO.Id != Guid.Empty)
        {
            // Add timeblock
            var timeBlock = await _timeBlockDAL.Retrieve(planningDTO.TimeBlockId);
            if (timeBlock != null)
            {
                var newTimeBlock = new PlanningTimeBlock()
                {
                    PlanningId = planning.Id,
                    TimeBlockId = planningDTO.TimeBlockId,
                    Date = planningDTO.Date.Date
                };
                planning.PlanningTimeBlocks.Add(newTimeBlock);
            }
        }

        await _planningDAL.Update(planning);
        return await RetrieveForTable(planning.Id);
    }


    public async Task Delete(Guid id)
    {
        Planning planning = await GetRecordAndCheckExistence(id);
        await _planningDAL.Delete(planning);
    }

    public async Task<PlanningDTO?> Retrieve(Guid id) => _mapper.Map<PlanningDTO>(await _planningDAL.Retrieve(id));

    public async Task<List<PlanningTableRowDTO>> RetrieveAll(Guid teacherId) => _mapper.Map<List<PlanningTableRowDTO>>(await _planningDAL.RetrieveForMainTable(id: Guid.Empty, teacherId: teacherId));

    public async Task<List<LabelValueDTO<Guid>>> RetrieveByGradeAndSubject(Guid gradeId, Guid subjectId) => _mapper.Map<List<LabelValueDTO<Guid>>>(await _planningDAL.RetrieveByGradeAndSubject(gradeId, subjectId));

    public async Task<PlanningDTO?> RetrieveBySubjectTimeBlockAndDate(Guid subjectId, Guid timeBlockId, string dateString)
    {
        DateTimeOffset date = DateTimeOffset.ParseExact(dateString, "yyyyMMdd", null);
        var planning = await _planningDAL.RetrieveBySubjectTimeBlockAndDate(subjectId, timeBlockId, date.Date);
        return _mapper.Map<PlanningDTO>(planning);
    }

    private async Task<Planning> GetRecordAndCheckExistence(Guid id)
    {
        Planning planning = await _planningDAL.Retrieve(id);
        if (planning is null)
            throw new EntityNotFoundException();
        return planning;
    }

    private async Task<Planning> GetRecordWithTimeBlocksAndCheckExistence(Guid id)
    {
        Planning planning = await _planningDAL.RetrieveWithTimeBlocks(id);
        if (planning is null)
            throw new EntityNotFoundException();
        return planning;
    }

    private async Task<PlanningTableRowDTO?> RetrieveForTable(Guid id)
    {
        if (id == Guid.Empty) return null;
        var rows = await _planningDAL.RetrieveForMainTable(id, Guid.Empty);
        if (rows == null || rows.Count == 0) return null;
        return _mapper.Map<PlanningTableRowDTO>(rows.FirstOrDefault());
    }
}