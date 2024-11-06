using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Api.Models.Request;

public class LoginCredentialsModel(string email, string password)
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [DataType(DataType.EmailAddress, ErrorMessage = ErrorConstants.EmailValidError)]
    public string Email { get; set; } = email;
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Password { get; set; } = password;
}