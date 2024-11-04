namespace medicalInformationSystem.Api.Models.Request;

public class QueryParameters
{
    public string Name { get; set; } = string.Empty;
    
    public int Page { get; set; } = 1;
    
    public int Size { get; set; } = 5;
    
    public int GetSkip() => (Page - 1) * Size;
}