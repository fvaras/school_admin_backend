using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ISubjectService
{
    Task<SubjectTableRowDTO> Create(SubjectForCreationDTO subjectDTO);
    Task<SubjectTableRowDTO> Update(int id, SubjectForUpdateDTO subjectDTO);
    Task Delete(int id);
    Task<SubjectDTO?> Retrieve(int id);
    Task<List<SubjectTableRowDTO>> RetrieveAll();
    Task<List<LabelValueDTO<int>>> RetrieveByGrade(int gradeId);
}
