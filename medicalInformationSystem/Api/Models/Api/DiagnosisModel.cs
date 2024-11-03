using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Models.Api;

public class DiagnosisModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.DiagnosisCodeLengthError)]
    public string Code { get; set; }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.DiagnosisNameLengthError)]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(DiagnosisType))]
    public DiagnosisType Type { get; set; }
}