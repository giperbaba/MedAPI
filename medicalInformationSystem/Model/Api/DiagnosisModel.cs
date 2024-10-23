using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Model.Api;

public class DiagnosisModel
{
    public Guid Id { get; set; }
    
    public DateTime CreateTime { get; set; }

    [MinLength(1, ErrorMessage = ErrorConstants.DiagnosisCodeLengthError)]
    public string Code { get; set; }

    [MinLength(1, ErrorMessage = ErrorConstants.DiagnosisNameLengthError)]
    public string Name { get; set; }

    public string Description { get; set; }
    
    [EnumDataType(typeof(DiagnosisType))]
    public DiagnosisType Type { get; set; }
}