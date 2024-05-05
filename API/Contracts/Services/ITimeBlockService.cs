using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ITimeBlockService
{
    Task<TimeBlockTableRowDTO> Create(TimeBlockForCreationDTO timeBlockDTO);
    Task<TimeBlockTableRowDTO> Update(int id, TimeBlockForUpdateDTO timeBlockDTO);
    Task Delete(int id);
    Task<TimeBlockDTO?> Retrieve(int id);
    Task<List<TimeBlockTableRowDTO>> RetrieveAll(int gradeId);

    Task CreateAllWeekTimeBlocksBase(int gradeId);
}