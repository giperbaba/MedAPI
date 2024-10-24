namespace medicalInformationSystem.Model.Api;

public class IncpectionCommentModel
{
    public Guid Id { get; set; }
    
    public DateTime CreateTime { get; set; }
    
    public Guid? PatientId { get; set; }
    
    public string? Content { get; set; }
    
    public DoctorModel Author { get; set; }
    
    public DateTime ModifyTime { get; set; }
}