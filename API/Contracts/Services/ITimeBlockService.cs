using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ITimeBlockService
{
    Task<TimeBlockTableRowDTO> Create(TimeBlockForCreationDTO timeBlockDTO);
    Task<TimeBlockTableRowDTO> Update(Guid id, TimeBlockForUpdateDTO timeBlockDTO);
    Task Delete(Guid id);
    Task<TimeBlockDTO?> Retrieve(Guid id);
    Task<List<TimeBlockTableRowDTO>> RetrieveAllByGradeAndTeacher(Guid gradeId, Guid teacherId);

    /********* GUARDIAN *********/
    Task<List<TimeBlockTableRowDTO>> RetrieveAllByStudentAndGuardian(Guid studentId, Guid guardianId);
    /********* GUARDIAN *********/

    /********* STUDENT *********/
    Task<List<TimeBlockTableRowDTO>> RetrieveAllByStudent(Guid studentId);
    /********* STUDENT *********/

    Task CreateAllWeekTimeBlocksBase(Guid gradeId);
}