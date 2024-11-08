using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Api.Models.Request;

public class InspectionShortModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DiagnosisModel Diagnosis { get; set; }
}