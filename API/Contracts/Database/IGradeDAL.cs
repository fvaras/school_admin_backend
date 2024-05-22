using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IGradeDAL
{
    Task<int> Create(Grade grade);
    Task Update(Grade grade);
    Task Delete(Grade grade);
    Task<Grade?> Retrieve(int id, bool trackChanges = false);
    Task<List<Grade>> RetrieveAll();
    Task<List<LabelValueFromDB<int>>> RetrieveForList();
    Task<List<LabelValueFromDB<int>>> RetrieveForListByTeacher(int teacherId);

    Task<List<int>> RetrieveTeachersId(int id);
}
