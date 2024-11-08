using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Data.Enum;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Api.Models.Api;

public class InspectionModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    public DateTime Date { get; set; }
    
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionAnamnesisLengthError)]
    public string? Anamnesis { get; set; }
    
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionComplaintsLengthError)]
    public string? Complaints { get; set; }
    
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionTreatmentLengthError)]
    public string? Treatment { get; set; }
    
    [EnumDataType(typeof(Conclusion))]
    public Conclusion Conclusion { get; set; }
    
    public DateTime? NextVisitDate { get; set; }
    
    public DateTime? DeathDate { get; set; }
    
    public Guid? BaseInspectionId { get; set; }
    
    public Guid? PreviousInspectionId { get; set; }
    
    public PatientModel Patient { get; set; }
    
    public DoctorModel Doctor { get; set; }
    
    public List<DiagnosisCreateModel> Diagnoses { get; set; }
    
    public List<InspectionConsultationModel?> Consultations { get; set; }
}