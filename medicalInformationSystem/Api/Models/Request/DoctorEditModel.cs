using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Data.Validator;
using medicalInformationSystem.Enum;
using static medicalInformationSystem.Configurations.Constants.RegexConstants;

namespace medicalInformationSystem.Models.Request;

public class DoctorEditModel
{
    public DoctorEditModel(string email, string name, DateTime birthday, Gender gender, string? phone)
    {
        Email = email;
        Name = name;
        Birthday = birthday;
        Gender = gender;
        Phone = phone;
    }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.EmailLengthError)]
    [DataType(DataType.EmailAddress, ErrorMessage = ErrorConstants.EmailValidError)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.NameLengthError)]
    public string Name { get; set; }
    
    [DatetimeValidator(ErrorMessage = ErrorConstants.IncorrectDateError)]
    public DateTime Birthday { get; set; }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [RegularExpression(pattern: RegexConstants.PhoneNumberRegex, ErrorMessage = ErrorConstants.PhoneNumberValidError)]
    public string? Phone { get; set; }
}