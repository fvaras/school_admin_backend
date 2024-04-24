using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ITeacherService
{
    Task<TeacherTableRowDTO> Create(TeacherForCreationDTO teacherDTO);
    Task<TeacherTableRowDTO> Update(int id, TeacherForUpdateDTO teacherDTO);
    Task Delete(int id);
    Task<TeacherDTO?> Retrieve(int id);
    Task<List<TeacherTableRowDTO>> RetrieveAll();

    Task<List<LabelValueDTO<int>>> RetrieveForList();

    Task<List<UserDerivedEntityDataForLists<int>>> RetrieveByNamesOrRut(string text);
}
