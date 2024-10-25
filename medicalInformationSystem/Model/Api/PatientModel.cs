using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Model.Api;

public class PatientModel
{
    public Guid Id { get; set; }
    
    public DateTime CreateTime { get; set; }
    
    [MinLength(1, ErrorMessage = ErrorConstants.PatientNameLengthError)]
    public string Name { get; set; }
    
    public DateTime? Birthday { get; set; }
    
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
}