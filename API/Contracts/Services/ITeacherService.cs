using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ITeacherService
{
    Task<TeacherTableRowDTO> Create(TeacherForCreationDTO teacherDTO);
    Task<TeacherTableRowDTO> Update(Guid id, TeacherForUpdateDTO teacherDTO);
    Task Delete(Guid id);
    Task<TeacherDTO?> Retrieve(Guid id);
    Task<List<Guid>> RetrieveIdByUser(Guid userId);
    Task<List<TeacherTableRowDTO>> RetrieveAll();

    Task<List<LabelValueDTO<Guid>>> RetrieveForList();

    Task<List<UserDerivedEntityDataForLists<int>>> RetrieveByNamesOrRut(string text);
}
