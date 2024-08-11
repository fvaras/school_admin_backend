using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ISubjectRepository
{
    Task Create(Subject subject);
    Task Update(Subject subject);
    Task Delete(Subject subject);
    Task<Subject?> Retrieve(Guid id, bool trackChanges = false);
    Task<List<SubjectTableRowDbDTO>> RetrieveAllForTable(Guid id);

    Task<List<LabelValueFromDB<Guid>>> RetrieveForListByGradeAndTeacherForList(Guid gradeId, Guid teacherId);
    Task<List<LabelValueFromDB<Guid>>> RetrieveByGrade(Guid gradeId);
}
