using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Api.Models.Interfaces;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Data.Validator;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Api.Models.Request;

public class PatientRegisterModel: IRegistrableUser
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.NameLengthError)]
    public string Name { get; set; }
    
    [DatetimeValidator(ErrorMessage = ErrorConstants.IncorrectDateError)]
    public DateTime Birthday { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
}