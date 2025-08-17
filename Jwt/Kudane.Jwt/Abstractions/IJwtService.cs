namespace Kudane.Jwt.Abstractions;

public interface IJwtService
{
    string SignToken(SignData signTokenModel);
    //string RefreshToken(IDictionary<string, string> claimsKeyValue);
}