using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Entities;

[Table("Doctors")] 
public class Doctor
{
    [Key]
    [Column("id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }

    [Column("name")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.DoctorNameLengthError)]
    public string Name { get; set; }

    [Column("birthday")]
    public DateTime? Birthday { get; set; }

    [Column("gender")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Column("email")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EmailAddress(ErrorMessage = ErrorConstants.DoctorEmailValidError)]
    public string Email { get; set; }

    [Column("phone")]
    [StringLength(maximumLength: 12)]
    [RegularExpression(pattern: RegexConstants.PhoneNumberRegex, ErrorMessage = ErrorConstants.DoctorPhoneNumberValidError)]
    public string? Phone { get; set; }
    
    [Column("password")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = ErrorConstants.DoctorPasswordLengthError)]
    [RegularExpression(pattern: RegexConstants.PasswordRegex, ErrorMessage = ErrorConstants.DoctorPasswordValidError)]
    public string? Password { get; set; }
    
    [Column("speciality_id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid SpecialityId { get; set; }
    
    [Column("create_time")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    public Guid Speciality { get; set; }
}