
using System.Security.Cryptography;
using System.Text;

namespace vl_dotnet_backend.Services;

public class PasswordService
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

    // Function to hash the password
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        passwordSalt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            passwordSalt,
            Iterations,
            Algorithm,
            KeySize
        );
        passwordHash = hash;
    }

    // Function to compare the password on login
    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, passwordSalt, Iterations, Algorithm, KeySize);
        return hashToCompare.SequenceEqual(passwordHash);
    }
}
