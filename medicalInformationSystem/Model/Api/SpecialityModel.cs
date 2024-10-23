using System.ComponentModel.DataAnnotations;

namespace medicalInformationSystem.Model.Api;

public class SpecialityModel
{
    public Guid Id { get; set; }
    
    DateTime CreateTime { get; set; }
    
    [MinLength(1, ErrorMessage = "Content must be at least 1 character long.")]
    public string Name { get; set; }
}