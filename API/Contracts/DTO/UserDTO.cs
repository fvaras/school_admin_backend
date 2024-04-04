namespace school_admin_api.Contracts.DTO;

public class UserBaseDTO
{
    public string UserName { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public byte Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public byte StateId { get; init; }
}

public class UserForCreationDTO : UserBaseDTO
{
    public string Password { get; init; }
}

public class UserForUpdateDTO : UserBaseDTO
{
}

public class UserDTO : UserBaseDTO
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}

public record UserInfoDTO
{
    public string UserName { get; init; }
    public string Rut { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    // public string Phone { get; set; }
    // public string Address { get; set; }
    // public byte Gender { get; set; }
    public int Profile { get; set; }
}