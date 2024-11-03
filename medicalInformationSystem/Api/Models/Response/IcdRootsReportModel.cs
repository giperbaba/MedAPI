namespace medicalInformationSystem.Models.Response;

public class IcdRootsReportModel
{
    public IcdRootsReportFiltersModel Filters { get; set; }
    
    public List<IcdRootsReportRecordModel>? Records { get; set; }
    
    public Dictionary<String, Int32>? SummaryByRoot { get; set; } 
}