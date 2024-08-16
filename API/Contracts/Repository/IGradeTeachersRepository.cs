namespace school_admin_api.Contracts.Repository;

public interface IGradeTeachersRepository
{
    Task ClearTeacherAssociations(Guid gradeId, bool saveChanges = true);
}
