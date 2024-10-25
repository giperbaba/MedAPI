using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Model.Api;

public record DoctorModel
{
    public DoctorModel(Guid id, DateTime createTime, string name, DateTime? birthday, Gender gender, string email,
        string phone)
    {
        Id = id;
        CreateTime = createTime;
        Name = name;
        Birthday = birthday;
        Gender = gender;
        Email = email;
        Phone = phone;
    }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.DoctorNameLengthError)]
    public string Name { get; set; }

    public DateTime? Birthday { get; set; }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public string Email { get; set; }

    public string Phone { get; set; }
}