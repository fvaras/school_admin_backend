namespace school_admin_api.Contracts.DTO;

public class StudentBaseDTO
{
    public string BloodGroup { get; init; }
    public string Allergies { get; init; }
    public DateTime? JoiningDate { get; init; }
    public byte StateId { get; init; }
    public Guid? GradeId { get; set; }
    public Guid Guardian1Id { get; set; }
    public Guid Guardian2Id { get; set; }
}

public class StudentForCreationDTO : StudentBaseDTO
{
    public UserForCreationDTO User { get; set; }
}

public class StudentForUpdateDTO : StudentBaseDTO
{
}

public class StudentDTO : StudentBaseDTO
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public UserDTO User { get; set; }
}

public class StudentTableRowDTO
{
    public Guid Id { get; init; }
    public string UserName { get; set; }
    public string UserId { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public byte Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public string BloodGroup { get; set; }
    public string Allergies { get; set; }
    public DateTime? JoiningDate { get; set; }
    public byte StateId { get; set; }
    public Guid GradeId { get; init; }
    public string GradeName { get; init; }
    // public DateTime CreatedAt { get; init; }
    // public DateTime? UpdatedAt { get; init; }
    // public string UserName { get; set; }
    // public Guid UserId { get; init; }
    // public byte UserStateId { get; init; }
}