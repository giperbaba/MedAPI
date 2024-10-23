using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;
using static medicalInformationSystem.Configurations.Constants.RegexConstants;

namespace medicalInformationSystem.Model.Request;

public class DoctorEditModel
{
    public DoctorEditModel(string email, string name, DateTime? birthday, Gender gender, string? phone)
    {
        Email = email;
        Name = name;
        Birthday = birthday;
        Gender = gender;
        Phone = phone;
    }

    [MinLength(1, ErrorMessage = ErrorConstants.DoctorEmailLengthError)]
    [RegularExpression(pattern: EmailRegex, ErrorMessage = ErrorConstants.DoctorEmailValidError)]
    public string Email { get; set; }
    
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.DoctorNameLengthError)]
    public string Name { get; set; }
    
    //TODO: Date validator
    public DateTime? Birthday { get; set; }

    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [RegularExpression(pattern: RegexConstants.PhoneNumberRegex, ErrorMessage = ErrorConstants.DoctorPhoneNumberValidError)]
    public string? Phone { get; set; }
}