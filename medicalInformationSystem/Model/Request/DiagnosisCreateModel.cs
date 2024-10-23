using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Model.Request;

public class DiagnosisCreateModel
{
    public Guid IcdDiagnosisId { get; set; }
    
    [StringLength(5000, ErrorMessage = "Diagnosis name must be between 5 000 characters.")]
    public string? Description { get; set; }
    
    public DiagnosisType Type { get; set; }
}