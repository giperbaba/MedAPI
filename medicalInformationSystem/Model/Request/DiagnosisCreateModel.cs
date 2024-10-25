using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Model.Request;

public class DiagnosisCreateModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid IcdDiagnosisId { get; set; }
    
    [StringLength(5000, ErrorMessage = ErrorConstants.DiagnosisDescriptionLengthError)]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(DiagnosisType))]
    public DiagnosisType Type { get; set; }
}