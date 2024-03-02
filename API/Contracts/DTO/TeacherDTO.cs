namespace school_admin_api.Contracts.DTO;

public class TeacherBaseDTO
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public byte IdGender { get; init; }
    public string ContactEmail { get; init; }
    public string ContactPhone { get; init; }
    public string PersonalEmail { get; init; }
    public string PersonalPhone { get; init; }
    public string PersonalAddress { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string Education { get; init; }
    public byte IdState { get; init; }
}

public class TeacherForCreationDTO : TeacherBaseDTO
{
}

public class TeacherForUpdateDTO : TeacherBaseDTO
{
}

public class TeacherDTO : TeacherBaseDTO
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
