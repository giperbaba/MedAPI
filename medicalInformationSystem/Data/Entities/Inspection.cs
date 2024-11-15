using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Data.Enum;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Data.Entities;

[Table("Inspections")]
public class Inspection
{
    [Key]
    [Column("id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }

    [Column("create_time")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }

    [Column("date")] public DateTime Date { get; set; }

    [Column("anamnesis")]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionAnamnesisLengthError)]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Anamnesis { get; set; }

    [Column("complaints")]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionComplaintsLengthError)]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Complaints { get; set; }

    [Column("treatment")]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = ErrorConstants.InspectionTreatmentLengthError)]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Treatment { get; set; }

    [Column("conclusion")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Conclusion))]
    public Conclusion Conclusion { get; set; }
    [Column("next_visit_date")] public DateTime? NextVisitDate { get; set; }
    
    [Column("death_date")] public DateTime? DeathDate { get; set; }

    [Column("base_inspection_id")] public Guid? BasePreviousInspectionId { get; set; } 
    [Column("previous_inspection_id")] public Guid? PreviousInspectionId { get; set; }
    [Column("doctor_id")] public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    [Column("patient_id")] public Guid PatientId { get; set; }
    public Patient Patient { get; set; }

    [Column("diagnoses")] 
    public ICollection<Diagnosis> Diagnoses { get; set; }

    [Column("consultations")] 
    public ICollection<Consultation> Consultations { get; set; }
}