namespace Kudane.Jwt.Abstractions;

public interface IJwtService
{
    string SignToken(SignTokenModel signTokenModel);
    //string RefreshToken(IDictionary<string, string> claimsKeyValue);
}