namespace medicalInformationSystem.Api.Models.Request;

public class DoctorLoginModel(string email, string password)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}