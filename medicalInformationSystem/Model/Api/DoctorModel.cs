using System.ComponentModel.DataAnnotations;
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

    public Guid Id { get; set; }

    DateTime CreateTime { get; set; }

    [MinLength(1, ErrorMessage = "Minimum length of name is 1.")]
    public string Name { get; set; }

    DateTime? Birthday { get; set; }

    public Gender Gender { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}