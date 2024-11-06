using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Data.Entities;

[Table("Patients")]
public class Patient
{
    [Key]
    [Column("id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Column("create_time")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    [Column("name")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.NameLengthError)]
    public string Name { get; set; }
    
    [Column("birthday")]
    public DateTime? Birthday { get; set; }
    
    [Column("gender")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
    
    public ICollection<Inspection> Inspections { get; set; }
    
    [Column("doctor_id")]
    public Guid DoctorId { get; set; } 
}