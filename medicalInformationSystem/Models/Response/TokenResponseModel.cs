namespace medicalInformationSystem.Models.Response;

public class TokenResponseModel(string token)
{
    public string Token { get; private set; } = token;
}