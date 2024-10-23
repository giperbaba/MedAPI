using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Model.Api;

public class DiagnosisModel
{
    public Guid Id { get; set; }
    
    DateTime CreateTime { get; set; }

    [MinLength(1, ErrorMessage = "Minimum length is 1")]
    public string Code { get; set; }

    [MinLength(1, ErrorMessage = "Minimum length is 1")]
    public string Name { get; set; }

    public string Description { get; set; }
    
    public DiagnosisType Type { get; set; }
}