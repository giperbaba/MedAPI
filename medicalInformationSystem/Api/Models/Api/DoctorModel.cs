using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Api.Models.Api;

public record DoctorModel(
    Guid Id,
    DateTime CreateTime,
    string Name,
    DateTime Birthday,
    Gender Gender,
    string Email,
    string Phone)
{
    public Guid Id { get; set; } = Id;


    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; } = CreateTime;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.NameLengthError)]
    public string Name { get; set; } = Name;

    public DateTime Birthday { get; set; } = Birthday;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; } = Gender;

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Email { get; set; } = Email;

    public string Phone { get; set; } = Phone;
}