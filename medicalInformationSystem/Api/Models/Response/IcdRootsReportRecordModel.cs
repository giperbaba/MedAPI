using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Enum;

namespace medicalInformationSystem.Models.Response;

public class IcdRootsReportRecordModel
{
    public string? PatientName { get; set; }
    
    public DateTime PatientBirthdate { get; set; }
    
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    public Dictionary<string, Int32?> VisitByRoot = new Dictionary<string, int?>();
}