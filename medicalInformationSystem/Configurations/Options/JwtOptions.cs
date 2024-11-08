namespace medicalInformationSystem.Configurations.Options;

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public double ExpiresHours { get; set; } = 0;
}