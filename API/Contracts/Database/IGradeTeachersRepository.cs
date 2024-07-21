namespace school_admin_api.Contracts.Database;

public interface IGradeTeachersRepository
{
    Task ClearTeacherAssociations(Guid gradeId, bool saveChanges = true);
}
