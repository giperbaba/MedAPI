using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Data.Enum;

namespace medicalInformationSystem.Api.Models.Request;

public class InspectionEditModel
{
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionAnamnesisLengthError)]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Anamnesis { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionAnamnesisLengthError)]
    public string Complaints { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionTreatmentLengthError)]
    public string Treatment { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Conclusion))]
    public Conclusion Conclusion { get; set; }
    
    public DateTime? NextVisitDate { get; set; }
    
    public DateTime? DeathDate { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.InspectionListDiagnosesLengthError)]
    public List<DiagnosisCreateModel> Diagnoses { get; set; }
}