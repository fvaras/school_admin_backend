using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using school_admin_api.Contracts.ConfigSettings;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Services;

public class JWTService : IJWTService
{
    private readonly TokenSettings _tokenSettings;

    public JWTService(
        IOptions<TokenSettings> tokenSettings
    )
    {
        _tokenSettings = tokenSettings.Value;
    }

    public string Encode<T>(T payload)
    {
        string secret = GetKey();
        IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric

        // Convert payload to a dictionary of claims
        var claims = JObject.FromObject(payload)
                            .ToObject<Dictionary<string, object>>();

        // Add expiration claim (exp) with 30 minutes from now
        claims.Add("exp", DateTimeOffset.UtcNow.AddSeconds(_tokenSettings.ExpirationSeconds).ToUnixTimeSeconds());

        var token = JwtBuilder.Create()
            .WithAlgorithm(algorithm)
            .WithSecret(secret)
            .AddClaims(claims)
            .Encode();

        return token;
    }

    public T Decode<T>(string token)
    {
        ValidationParameters validationParameters = ValidationParameters.Default;
        validationParameters.ValidateSignature = true;
        validationParameters.ValidateExpirationTime = true;
        validationParameters.ValidateIssuedTime = true;

        string secret = GetKey();
        var payload = JwtBuilder.Create()
                    .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                    .WithValidationParameters(validationParameters)
                    .WithSecret(secret)
                    .MustVerifySignature()
                    .Decode<T>(token);
        return payload;
    }

    // public T Decode<T>(string token)
    // {
    //     string secret = GetKey();

    //     var payload = JwtBuilder.Create()
    //         .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
    //         .WithSecret(secret)
    //         .MustVerifySignature()
    //         .Decode<T>(token);

    //     return payload;
    // }

    private string GetKey()
    {
        // TODO: Get from ENVIRONMENT VARIABLES
        return _tokenSettings.Key;
    }
}
