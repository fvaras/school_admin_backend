using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.Extensions.Options;
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

        // TODO: Make this implementation according to https://github.com/jwt-dotnet/jwt
        // IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
        IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric

        IJsonSerializer serializer = new JsonNetSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

        var token = encoder.Encode(payload, secret);
        return token;
    }

    public T Decode<T>(string token)
    {
        ValidationParameters validationParameters = ValidationParameters.Default;
        validationParameters.ValidateSignature = true;
        validationParameters.ValidateExpirationTime = true;
        validationParameters.ValidateIssuedTime = true;
        validationParameters.TimeMargin = 100;

        string secret = GetKey();
        var payload = JwtBuilder.Create()
                    .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                    .WithValidationParameters(validationParameters)
                    .WithSecret(secret)
                    .MustVerifySignature()
                    .Decode<T>(token);
        return payload;
    }

    private string GetKey()
    {
        // TODO: Get from ENVIRONMENT VARIABLES
        return _tokenSettings.Key;
    }
}
