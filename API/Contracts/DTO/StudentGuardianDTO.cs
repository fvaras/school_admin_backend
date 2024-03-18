namespace school_admin_api.Contracts.DTO;

public class StudentGuardianBaseDTO
{
    public string Relation { get; set; }
}

public class StudentGuardianForCreationDTO : StudentGuardianBaseDTO
{
    public UserForCreationDTO User { get; set; }
}

public class StudentGuardianForUpdateDTO : StudentGuardianBaseDTO
{
}

public class StudentGuardianDTO : StudentGuardianBaseDTO
{
    public int Id { get; init; }
    public byte IdState { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public UserDTO User { get; set; }
}
