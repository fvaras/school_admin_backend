namespace school_admin_api.Contracts.DTO;

public class UserBaseDTO
{
    public string UserName { get; init; }
    public string Rut { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
}

public class UserForCreationDTO : UserBaseDTO
{
    public string Password { get; init; }
}

public class UserForUpdateDTO : UserBaseDTO
{
    public int Id { get; init; }
    public byte IdState { get; init; }
}

public class UserDTO : UserBaseDTO
{
    public int Id { get; init; }
    public byte IdState { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
