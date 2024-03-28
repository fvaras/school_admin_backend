using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ITeacherService
{
    Task<int> Create(TeacherForCreationDTO teacherDTO);
    Task Update(int id, TeacherForUpdateDTO teacherDTO);
    Task Delete(int id);
    Task<TeacherDTO?> Retrieve(int id);
    Task<List<TeacherTableRowDTO>> RetrieveAll();

    Task<List<LabelValueDTO<int>>> RetrieveForList();
}
