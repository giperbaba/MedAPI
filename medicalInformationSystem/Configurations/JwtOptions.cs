namespace medicalInformationSystem.Configurations;

public class JwtOptions
{
    public string SecretKey { get; set; } = "giperbabasecretkeyicantstandbackendpleasehelpme";
    
    public double ExpiresHours { get; set; } = 0;
}