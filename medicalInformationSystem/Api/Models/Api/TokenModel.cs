namespace medicalInformationSystem.Models.Api;

public class TokenModel(string token)
{
    public string Token { get; set; } = token;
}