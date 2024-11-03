using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;
using medicalInformationSystem.Models.Request;

namespace medicalInformationSystem.Api.Models.Request;

public class InspectionCreateModel(
    DateTime date,
    string anamnesis,
    string complaints,
    string treatment,
    Conclusion conclusion,
    DateTime? nextVisitDate,
    DateTime? deathDate,
    Guid? previousInspectionId,
    List<DiagnosisCreateModel> diagnoses,
    List<ConsultationCreateModel?> consultations)
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime Date { get; set; } = date;

    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionAnamnesisLengthError)]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Anamnesis { get; set; } = anamnesis;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionComplaintsLengthError)]
    public string Complaints { get; set; } = complaints;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionTreatmentLengthError)]
    public string Treatment { get; set; } = treatment;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Conclusion))]
    public Conclusion Conclusion { get; set; } = conclusion;

    //TODO: Date and time of the next visit in case of Disease conclusion (UTC)
    public DateTime? NextVisitDate { get; set; } = nextVisitDate;

    //TODO: Date and time of the death in case of Death conclusion (UTC)
    public DateTime? DeathDate { get; set; } = deathDate;

    public Guid? PreviousInspectionId { get; set; } = previousInspectionId;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.InspectionListDiagnosesLengthError)]
    public List<DiagnosisCreateModel> Diagnoses { get; set; } = diagnoses;

    public List<ConsultationCreateModel?> Consultations { get; set; } = consultations;
}