using Server.Data.Enums;

namespace Server.Data.Interfaces;

public interface TokenServiceInterface
{
    string Decrypt(string token);
    string Generate(RoleEnum role);
}