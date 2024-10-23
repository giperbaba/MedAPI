namespace medicalInformationSystem.Model.Response;

public class Icd10RecordModel
{
    public Guid Id { get; set; }
    
    public DateTime CreateTime { get; set; }
    
    public string? Code { get; set; }
    
    public string? Name { get; set; }
}