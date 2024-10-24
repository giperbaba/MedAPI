namespace medicalInformationSystem.Model.Response;

public class IcdRootsReportFilterModel
{
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }
    
    public List<string>? IcdRoots { get; set; } = new();
}