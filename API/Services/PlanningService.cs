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
    private readonly IPlanningRepository _planningRepository;
    private readonly ITimeBlockDAL _timeBlockDAL;
    private readonly IPlanningTimeBlockDAL _planningTimeBlockDAL;
    private readonly IGuardianService _guardianService;
    private readonly IMapper _mapper;

    public PlanningService(
        ILoggerService logger,
        IPlanningRepository planningDAL,
        ITimeBlockDAL timeBlockDAL,
        IPlanningTimeBlockDAL planningTimeBlockDAL,
        IGuardianService guardianService,
        IMapper mapper
        )
    {
        _logger = logger;
        _planningRepository = planningDAL;
        _timeBlockDAL = timeBlockDAL;
        _planningTimeBlockDAL = planningTimeBlockDAL;
        _guardianService = guardianService;
        _mapper = mapper;
    }

    public async Task<PlanningTableRowDTO> Create(PlanningForCreationDTO planningDTO)
    {
        Planning planning = _mapper.Map<Planning>(planningDTO);
        await _planningRepository.Create(planning);
        return await RetrieveForTable(planning.Id);
    }

    public async Task<PlanningTableRowDTO> Update(Guid id, PlanningForUpdateDTO planningDTO)
    {
        Planning planning = await GetRecordAndCheckExistence(id);
        _mapper.Map(planningDTO, planning);
        await _planningRepository.Update(planning);
        return await RetrieveForTable(planning.Id);
    }

    public async Task<PlanningTableRowDTO> UpdateWithTimeBlocks(Guid id, PlanningWithTimeBlocksForUpdateDTO planningDTO)
    {
        Planning planning = null;
        planning = await GetRecordWithTimeBlocksAndCheckExistence(id);
        _mapper.Map(planningDTO as PlanningForUpdateDTO, planning);
        await _planningRepository.Update(planning);

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

        await _planningRepository.Update(planning);
        return await RetrieveForTable(planning.Id);
    }


    public async Task Delete(Guid id)
    {
        Planning planning = await GetRecordAndCheckExistence(id);
        await _planningRepository.Delete(planning);
    }

    public async Task<PlanningDTO?> Retrieve(Guid id) => _mapper.Map<PlanningDTO>(await _planningRepository.Retrieve(id));

    public async Task<List<PlanningTableRowDTO>> RetrieveAll(Guid teacherId) => _mapper.Map<List<PlanningTableRowDTO>>(await _planningRepository.RetrieveForMainTable(id: Guid.Empty, teacherId: teacherId));

    public async Task<List<LabelValueDTO<Guid>>> RetrieveByGradeAndSubjectForList(Guid gradeId, Guid subjectId) => _mapper.Map<List<LabelValueDTO<Guid>>>(await _planningRepository.RetrieveByGradeAndSubjectForList(gradeId, subjectId));

    public async Task<List<PlanningTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid guardianId, Guid studentId, Guid subjectId)
    {
        // Integrity guardianId/studentId
        await _guardianService.CheckRelationWithStudent(guardianId, studentId);

        // TODO: Validate integrity studentId/subjectId

        return _mapper.Map<List<PlanningTableRowDTO>>(await _planningRepository.RetrieveForTable(subjectId));
    }

    public async Task<PlanningDTO?> RetrieveBySubjectTimeBlockAndDate(Guid subjectId, Guid timeBlockId, string dateString)
    {
        DateTimeOffset date = DateTimeOffset.ParseExact(dateString, "yyyyMMdd", null);
        var planning = await _planningRepository.RetrieveBySubjectTimeBlockAndDate(subjectId, timeBlockId, date.Date);
        return _mapper.Map<PlanningDTO>(planning);
    }

    private async Task<Planning> GetRecordAndCheckExistence(Guid id)
    {
        Planning planning = await _planningRepository.Retrieve(id);
        if (planning is null)
            throw new EntityNotFoundException();
        return planning;
    }

    private async Task<Planning> GetRecordWithTimeBlocksAndCheckExistence(Guid id)
    {
        Planning planning = await _planningRepository.RetrieveWithTimeBlocks(id);
        if (planning is null)
            throw new EntityNotFoundException();
        return planning;
    }

    private async Task<PlanningTableRowDTO?> RetrieveForTable(Guid id)
    {
        if (id == Guid.Empty) return null;
        var rows = await _planningRepository.RetrieveForMainTable(id, Guid.Empty);
        if (rows == null || rows.Count == 0) return null;
        return _mapper.Map<PlanningTableRowDTO>(rows.FirstOrDefault());
    }
}