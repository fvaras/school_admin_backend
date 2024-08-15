using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IGradeRepository
{
    Task<Guid> Create(Grade grade);
    Task Update(Grade grade);
    Task Delete(Grade grade);
    Task<Grade?> Retrieve(Guid id, bool trackChanges = false);
    Task<Grade?> RetrieveWithTeachers(Guid id, bool trackChanges = false);
    Task ClearTeacherAssociations(Guid id);
    Task<List<Grade>> RetrieveAll();
    Task<List<LabelValueFromDB<Guid>>> RetrieveForList();

    /********* TEACHER *********/
    // Task<List<LabelValueFromDB<Guid>>> RetrieveForListByTeacher(Guid teacherId, Guid subjectId);
    /********* TEACHER *********/

    Task<List<Guid>> RetrieveTeachersId(Guid id);
}