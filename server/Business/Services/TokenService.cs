using System.Security.Cryptography;
using Server.Data.Interfaces;
using Server.Data.Enums;
using System.Text;

namespace Server.Business.Services;

public sealed class TokenService : TokenServiceInterface
{
    private readonly string _secretKey;

    public TokenService(IConfiguration configuration)
    {
        _secretKey = configuration["Secret"] ?? "";

        if (string.IsNullOrEmpty(_secretKey))
            throw new ApplicationException("Missing the internal token secret");
    }

    public string Decrypt(string token)
    {
        using (var aesAlg = Aes.Create())
        {
            aesAlg.IV = new byte[16];
            aesAlg.Key = Encoding.UTF8.GetBytes(_secretKey);
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            byte[] encryptedData = Convert.FromBase64String(token);
            return DecryptStringFromAesBytes(encryptedData, decryptor);
        }
    }

    private string DecryptStringFromAesBytes(byte[] cipherText, ICryptoTransform decryptor)
    {
        using (var ms = new MemoryStream(cipherText))
        {
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            {
                using (var reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }

    private byte[] EncryptStringToAesBytes(string plainText, ICryptoTransform encryptor)
    {
        byte[] encrypted;
        using (var ms = new MemoryStream())
        {
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                using (var writer = new StreamWriter(cs))
                {
                    writer.Write(plainText);
                }
            }
            encrypted = ms.ToArray();
        }
        return encrypted;
    }

    public string Generate(RoleEnum role)
    {
        using (var aesAlg = Aes.Create())
        {
            aesAlg.IV = new byte[16];
            aesAlg.Key = Encoding.UTF8.GetBytes(_secretKey);
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            byte[] encryptedData = EncryptStringToAesBytes(role.ToString(), encryptor);
            return Convert.ToBase64String(encryptedData);
        }
    }
}