using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IGradeService
{
    Task<GradeDTO> Create(GradeForCreationDTO gradeDTO);
    Task<GradeDTO> Update(Guid id, GradeForUpdateDTO gradeDTO);
    Task Delete(Guid id);
    Task<GradeDTO?> Retrieve(Guid id);
    Task<List<GradeDTO>> RetrieveAll();
    Task<List<LabelValueDTO<Guid>>> RetrieveForList();

    /********* TEACHER *********/
    // Task<List<LabelValueDTO<Guid>>> RetrieveForListByTeacher(Guid teacherId, Guid subjectId);
    /********* TEACHER *********/

    Task<List<Guid>> RetrieveTeachersId(Guid id);
}
