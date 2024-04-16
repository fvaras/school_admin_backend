namespace school_admin_api.Contracts.DTO;

public class StudentGuardianBaseDTO
{
    public string Relation { get; set; }
    public byte StateId { get; init; }
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
    public byte StateId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public UserDTO User { get; set; }
}

public class StudentGuardianTableRowDTO
{
    public int Id { get; init; }
    public string UserName { get; set; }
    public string UserId { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    // public byte Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public byte StateId { get; set; }
    public string Relation { get; set; }
}
