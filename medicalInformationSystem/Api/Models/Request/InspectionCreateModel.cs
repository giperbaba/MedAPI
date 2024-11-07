using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Data.Enum;
using medicalInformationSystem.Enum;
using medicalInformationSystem.Models.Request;

namespace medicalInformationSystem.Api.Models.Request;

public class InspectionCreateModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
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

    public Guid? PreviousInspectionId { get; set; }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.InspectionListDiagnosesLengthError)]
    public ICollection<DiagnosisCreateModel> Diagnoses { get; set; }

    public ICollection<ConsultationCreateModel?> Consultations { get; set; }
}