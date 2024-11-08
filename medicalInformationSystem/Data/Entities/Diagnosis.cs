using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Data.Entities;

[Table("Diagnosis")]
public class Diagnosis
{
    [Key]
    [Column("id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Column("create_time")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }

    [Column("code")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.DiagnosisCodeLengthError)]
    public string Code { get; set; }

    [Column("name")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.DiagnosisNameLengthError)]
    public string Name { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("diagnosis_type")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(DiagnosisType))]
    public DiagnosisType Type { get; set; }
    
    [Column("diagnosis_id")]
    public Guid DiagnosisIcd10Id  { get; set; }
    
    [Column("inspection_id")]
    public Guid InspectionId { get; set; }
    public Inspection Inspection { get; set; }
}