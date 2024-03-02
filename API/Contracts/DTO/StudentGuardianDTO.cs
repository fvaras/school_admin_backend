namespace school_admin_api.Contracts.DTO;

public class StudentGuardianBaseDTO
{
    public string Rut { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public byte IdGender { get; init; }
    public string Relation { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Address { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public byte IdState { get; init; }
}

public class StudentGuardianForCreationDTO : StudentGuardianBaseDTO
{
}

public class StudentGuardianForUpdateDTO : StudentGuardianBaseDTO
{
}

public class StudentGuardianDTO : StudentGuardianBaseDTO
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
