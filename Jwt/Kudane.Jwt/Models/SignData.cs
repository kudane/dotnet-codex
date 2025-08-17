namespace Kudane.Jwt.Models;

public sealed class SignData
{
    public IDictionary<string, string> ClaimsKeyValue { get; init; }
    public string SecretKey { get; init; }
    public int ExpiresInMinutes { get; init; }

    public SignData(IDictionary<string, string> claimsKeyValues, string secretKey, int expiresInMinutes)
    {
        if (claimsKeyValues == null)
        {
            throw new ArgumentNullException(nameof(claimsKeyValues));
        }

        if (claimsKeyValues.Any() == false)
        {
            throw new ArgumentException("claimsKeyValues must contain more than one item.", nameof(claimsKeyValues));
        }

        if (string.IsNullOrEmpty(secretKey))
        {
            throw new ArgumentNullException(nameof(secretKey));
        }

        if (expiresInMinutes == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(expiresInMinutes), "expiresInMinutes cannot be zero.");
        }

        ClaimsKeyValue = claimsKeyValues;
        SecretKey = secretKey;
        ExpiresInMinutes = expiresInMinutes;
    }
}
