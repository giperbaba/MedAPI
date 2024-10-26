using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Entities;

[Table("Specialities")]
public class Speciality
{
    public Speciality(string name)
    {
        Name = name;
    }

    [Key] 
    [Column("id")] 
    public Guid Id { get; set; }
    
    
    [Column("name")]
    [Required]
    [MinLength(1, ErrorMessage = ErrorConstants.SpecialityNameLengthError)]
    public string Name { get; set; }
    
    [Column("create_time")]
    public DateTime CreateTime { get; set; }
    
    
}