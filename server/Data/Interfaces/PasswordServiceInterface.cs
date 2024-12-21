namespace Server.Data.Interfaces;

public interface PasswordServiceInterface
{
    string Generate();
    bool Validate(string input);
}