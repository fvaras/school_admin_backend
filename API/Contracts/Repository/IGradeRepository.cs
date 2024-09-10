using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

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
    // Task<List<LabelValueFromDB<Guid>>> RetrieveByTeacherForList(Guid teacherId);
    Task<List<LabelValueFromDB<Guid>>> RetrieveByMainTeacherForList(Guid teacherId);
    /********* TEACHER *********/

    Task<List<Guid>> RetrieveTeachersId(Guid id);
}
