namespace school_admin_api.Contracts.DTO;

public record AuthInfoDTO
{
    public UserInfoDTO User { get; set; }
    public string Token { get; set; }
}

public record TokenInfoDTO
{
    public string Username { get; set; }
    public Guid ProfileId { get; set; }
    public Guid UserProfileId { get; set; }
}