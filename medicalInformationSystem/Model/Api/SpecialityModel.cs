using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Model.Api;

public class SpecialityModel
{
    public Guid Id { get; set; }
    
    public DateTime CreateTime { get; set; }
    
    [MinLength(1, ErrorMessage = ErrorConstants.SpecialityNameLengthError)]
    public string Name { get; set; }
}