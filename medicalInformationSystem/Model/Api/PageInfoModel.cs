namespace medicalInformationSystem.Model.Api;

public class PageInfoModel
{
    public Int32 Size { get; set; }
    
    public Int32 Count { get; set; }
    
    public Int32 Current { get; set; }
}