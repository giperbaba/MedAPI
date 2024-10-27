using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Models.Request;

public class DoctorLoginModel
{
    public DoctorLoginModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.DoctorEmailLengthError)]
    [RegularExpression(pattern: RegexConstants.EmailRegex, ErrorMessage = ErrorConstants.DoctorEmailValidError)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(6, ErrorMessage = ErrorConstants.DoctorPasswordLengthError)]
    [RegularExpression(pattern: RegexConstants.PasswordRegex, ErrorMessage = ErrorConstants.DoctorPasswordValidError)]
    public string Password { get; set; }
}