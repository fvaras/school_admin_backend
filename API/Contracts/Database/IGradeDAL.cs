using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IGradeDAL
{
    Task<Guid> Create(Grade grade);
    Task Update(Grade grade);
    Task Delete(Grade grade);
    Task<Grade?> Retrieve(Guid id, bool trackChanges = false);
    Task<List<Grade>> RetrieveAll();
    Task<List<LabelValueFromDB<Guid>>> RetrieveForList();
    Task<List<LabelValueFromDB<Guid>>> RetrieveForListByTeacher(Guid teacherId);

    Task<List<Guid>> RetrieveTeachersId(Guid id);
}
