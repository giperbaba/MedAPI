using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Api.Models.Api;

public class PatientModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.NameLengthError)]
    public string Name { get; set; }
    
    public DateTime? Birthday { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
}