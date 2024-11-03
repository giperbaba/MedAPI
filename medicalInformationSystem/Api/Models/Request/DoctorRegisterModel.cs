using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Api.Models.Request;

public class DoctorRegisterModel(
    string name,
    string password,
    string email,
    DateTime birthday,
    Gender gender,
    string? phone,
    Guid specialityId)

{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.NameLengthError)]
    public string Name { get; set; } = name;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(6, ErrorMessage = ErrorConstants.PasswordLengthError)]
    public string Password { get; set; } = password;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.EmailLengthError)]
    [RegularExpression(pattern: RegexConstants.EmailRegex, ErrorMessage = ErrorConstants.EmailValidError)]
    public string Email { get; set; } = email;

    //TODO: Date validator
    public DateTime Birthday { get; set; } = birthday;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; } = gender;

    [RegularExpression(pattern: RegexConstants.PhoneNumberRegex, ErrorMessage = ErrorConstants.PhoneNumberValidError)]
    public string? Phone { get; set; } = phone;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid SpecialityId { get; set; } = specialityId;
}