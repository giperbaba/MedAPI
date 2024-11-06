using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;
using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;

namespace medicalInformationSystem.Model.Api;

public class InspectionModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    public DateTime Date { get; set; }
    
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionAnamnesisLengthError)]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Anamnesis { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionComplaintsLengthError)]
    public string Complaints { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionTreatmentLengthError)]
    public string Treatment { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Conclusion))]
    public Conclusion Conclusion { get; set; }
    
    //TODO: Date and time of the next visit in case of Disease conclusion (UTC)
    public DateTime? NextVisitDate { get; set; }
    
    //TODO: Date and time of the death in case of Death conclusion (UTC)
    public DateTime? DeathDate { get; set; }
    
    public Guid? BaseInspectionId { get; set; }
    
    public Guid? PreviousInspectionId { get; set; }
    
    public PatientModel Patient { get; set; }
    
    public DoctorModel Doctor { get; set; }
    
    public List<DiagnosisCreateModel> Diagnoses { get; set; }
    
    public List<ConsultationCreateModel?> Consultations { get; set; }
}