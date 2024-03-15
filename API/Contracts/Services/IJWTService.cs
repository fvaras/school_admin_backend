namespace school_admin_api.Contracts.Services;

public interface IJWTService
{
    string Encode<T>(T payload);
    T Decode<T>(string token);
}
