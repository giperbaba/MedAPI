using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;
using static medicalInformationSystem.Configurations.Constants.RegexConstants;

namespace medicalInformationSystem.Model.Request;

public class DoctorRegisterModel(
    string name,
    string password,
    string email,
    DateTime? birthday,
    Gender gender,
    string? phone,
    Guid speciality)
{
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.DoctorNameLengthError)]
    public string Name { get; set; } = name;

    [MinLength(6, ErrorMessage = ErrorConstants.DoctorPasswordLengthError)]
    [RegularExpression(pattern: PasswordRegex, ErrorMessage = ErrorConstants.DoctorPasswordValidError)]
    public string Password { get; set; } = password;

    [MinLength(1, ErrorMessage = ErrorConstants.DoctorEmailLengthError)]
    [RegularExpression(pattern: EmailRegex, ErrorMessage = ErrorConstants.DoctorEmailValidError)]
    public string Email { get; set; } = email;

    //TODO: Date validator
    public DateTime? Birthday { get; set; } = birthday;

    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; } = gender;

    [RegularExpression(pattern: RegexConstants.PhoneNumberRegex, ErrorMessage = ErrorConstants.DoctorPhoneNumberValidError)]
    public string? Phone { get; set; } = phone;

    public Guid Speciality { get; set; } = speciality;
}