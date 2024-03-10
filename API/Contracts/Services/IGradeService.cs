using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IGradeService
{
    Task<int> Create(GradeForCreationDTO gradeDTO);
    Task Update(int id, GradeForUpdateDTO gradeDTO);
    Task Delete(int id);
    Task<GradeDTO?> Retrieve(int id);
    Task<List<GradeDTO>> RetrieveAll();

    Task<List<int>> RetrieveTeachersId(int id);
}
