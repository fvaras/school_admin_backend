using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface IStudentRepository
{
    Task<Guid> Create(Student student);
    Task Update(Student student);
    Task Delete(Student student);
    Task<Student?> Retrieve(Guid id, bool trackChanges = false);
    Task<Student?> RetrieveByUserId(Guid userId, bool trackChanges = false);
    Task<Student?> RetrieveWithUserAndProfiles(Guid id, bool trackChanges = true);
    Task<Student?> RetrieveWithGuardians(Guid id, bool trackChanges = true);
    Task<Student?> RetrieveForMainTable(Guid id);
    Task<List<Student>> RetrieveAll();
    Task<List<Guid>> RetrieveGuardiansId(Guid id);


    /********* GUARDIAN *********/
    Task<List<LabelValueFromDB<Guid>>> GetByGuardianForList(Guid guardianId, Guid studentId);
    /********* GUARDIAN *********/
}
