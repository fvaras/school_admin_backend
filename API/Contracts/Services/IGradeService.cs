using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IGradeService
{
    Task<GradeDTO> Create(GradeForCreationDTO gradeDTO);
    Task<GradeDTO> Update(int id, GradeForUpdateDTO gradeDTO);
    Task Delete(int id);
    Task<GradeDTO?> Retrieve(int id);
    Task<List<GradeDTO>> RetrieveAll();
    Task<List<LabelValueDTO<int>>> RetrieveForList();
    Task<List<LabelValueDTO<int>>> RetrieveForListByTeacher(int teacherId);

    Task<List<int>> RetrieveTeachersId(int id);
}
