using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Data.Entities;

[Table("Consultation")]
public class Consultation
{
    [Column("id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }

    [Column("create_time")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    [Column("comment")]
    public string Comment { get; set; }

    [Column("inspection_id")]
    public Guid InspectionId { get; set; }
    public Inspection Inspection { get; set; }

    [Column("speciality_id")]
    public Guid SpecialityId { get; set; }
    public Speciality Speciality { get; set; }
}