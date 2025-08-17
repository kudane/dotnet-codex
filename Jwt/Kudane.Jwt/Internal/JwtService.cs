namespace Kudane.Jwt.Internal;

internal class JwtService : IJwtService
{
    public string SignToken(SignData signData)
    {
        var key = Encoding.ASCII.GetBytes(signData.SecretKey);

        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = signData.ClaimsKeyValue
            .Select(keyvalue => new Claim(keyvalue.Key, keyvalue.Value))
            .ToArray();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(signData.ExpiresInMinutes),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            )
        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }
}
