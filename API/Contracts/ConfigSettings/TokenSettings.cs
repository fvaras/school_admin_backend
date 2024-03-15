namespace school_admin_api.Contracts.ConfigSettings;

public class TokenSettings
{
    public string Key { get; set; } // TODO: Get from ENVIRONMENT VARIABLES
    public int ExpirationSeconds { get; set; }
}
