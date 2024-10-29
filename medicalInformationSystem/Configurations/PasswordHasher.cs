namespace medicalInformationSystem.Configurations;

public static class PasswordHasher
{
    public static string Generate(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    
    public static bool Verify(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}