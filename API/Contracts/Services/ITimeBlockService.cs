using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ITimeBlockService
{
    Task<TimeBlockTableRowDTO> Create(TimeBlockForCreationDTO timeBlockDTO);
    Task<TimeBlockTableRowDTO> Update(Guid id, TimeBlockForUpdateDTO timeBlockDTO);
    Task Delete(Guid id);
    Task<TimeBlockDTO?> Retrieve(Guid id);
    Task<List<TimeBlockTableRowDTO>> RetrieveAll(Guid gradeId, Guid teacherId);

    Task CreateAllWeekTimeBlocksBase(Guid gradeId);
}