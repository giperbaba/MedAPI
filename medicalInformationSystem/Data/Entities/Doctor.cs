using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Data.Entities;

[Table("Doctors")] 
public class Doctor
{
    [Key]
    [Column("id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }

    [Column("name")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.NameLengthError)]
    public string Name { get; set; }

    [Column("birthday")]
    public DateTime Birthday { get; set; }

    [Column("gender")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Column("email")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EmailAddress(ErrorMessage = ErrorConstants.EmailValidError)]
    public string Email { get; set; }

    [Column("phone")]
    [StringLength(maximumLength: 12)]
    [RegularExpression(pattern: RegexConstants.PhoneNumberRegex, ErrorMessage = ErrorConstants.PhoneNumberValidError)]
    public string? Phone { get; set; }
    
    [Column("password")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = ErrorConstants.PasswordLengthError)]
    [RegularExpression(pattern: RegexConstants.PasswordRegex, ErrorMessage = ErrorConstants.PasswordValidError)]
    public string? Password { get; set; }
    
    [Column("speciality_id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid SpecialityId { get; set; }
    
    [Column("create_time")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }

    public Speciality Speciality { get; set; }
    
    public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
}