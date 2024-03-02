using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ICourseService
{
    Task<int> Create(CourseForCreationDTO courseDTO);
    Task Update(int id, CourseForUpdateDTO courseDTO);
    Task Delete(int id);
    Task<CourseDTO?> Retrieve(int id);
    Task<List<CourseDTO>> RetrieveAll();
}
