namespace school_admin_api.Contracts.DTO;

public class TeacherBaseDTO
{
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string Education { get; set; }
    public byte StateId { get; set; }
}

public class TeacherForCreationDTO : TeacherBaseDTO
{
    public UserForCreationDTO User { get; set; }
}

public class TeacherForUpdateDTO : TeacherBaseDTO
{
    // public UserForUpdateDTO User { get; set; }
}

public class TeacherDTO : TeacherBaseDTO
{
    public Guid Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
    public UserDTO User { get; set; }
}

public class TeacherTableRowDTO
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
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public DateTimeOffset? BirthDate { get; set; }
    public string Education { get; set; }
    public byte StateId { get; set; }
    // public DateTimeOffset CreatedAt { get; init; }
    // public DateTimeOffset? UpdatedAt { get; init; }
    // public string UserName { get; set; }
    // public Guid UserId { get; init; }
    // public byte UserStateId { get; init; }
}
