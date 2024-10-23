using System.ComponentModel.DataAnnotations;

namespace medicalInformationSystem.Model.Request;

public class DoctorRegisiterModel
{
    [StringLength(1000, MinimumLength = 1, ErrorMessage = "Doctor Name must be between 1 and 1000 characters")]
    public string Name { get; set; }
}