using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Api.Models.Api;

public class InspectionCommentModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    public Guid? PatientId { get; set; }
    
    public string? Content { get; set; }
    
    public DoctorModel Author { get; set; }
    
    public DateTime ModifyTime { get; set; }
}