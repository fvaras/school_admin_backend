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
    private readonly IMapper _mapper;

    public PlanningService(
        ILoggerService logger,
        IPlanningDAL planningDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _planningDAL = planningDAL;
        _mapper = mapper;
    }

    public async Task<PlanningTableRowDTO> Create(PlanningForCreationDTO planningDTO)
    {
        Planning planning = _mapper.Map<Planning>(planningDTO);
        await _planningDAL.Create(planning);
        return await RetrieveForTable(planning.Id);
    }

    public async Task<PlanningTableRowDTO> Update(int id, PlanningForUpdateDTO planningDTO)
    {
        Planning planning = await GetRecordAndCheckExistence(id);
        _mapper.Map(planningDTO, planning);
        await _planningDAL.Update(planning);
        return await RetrieveForTable(planning.Id);
    }

    public async Task Delete(int id)
    {
        Planning planning = await GetRecordAndCheckExistence(id);
        await _planningDAL.Delete(planning);
    }

    public async Task<PlanningDTO?> Retrieve(int id) => _mapper.Map<PlanningDTO>(await _planningDAL.Retrieve(id));

    public async Task<List<PlanningTableRowDTO>> RetrieveAll() => _mapper.Map<List<PlanningTableRowDTO>>(await _planningDAL.RetrieveAll());

    private async Task<Planning> GetRecordAndCheckExistence(int id)
    {
        Planning planning = await _planningDAL.Retrieve(id);
        if (planning is null)
            throw new EntityNotFoundException();
        return planning;
    }

    private async Task<PlanningTableRowDTO?> RetrieveForTable(int id)
    {
        if (id == 0) return null;
        var rows = await _planningDAL.RetrieveForMainTable(id);
        if (rows == null || rows.Count == 0) return null;
        return _mapper.Map<PlanningTableRowDTO>(rows.FirstOrDefault());
    }
}