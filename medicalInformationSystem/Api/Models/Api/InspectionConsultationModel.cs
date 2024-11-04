using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Model.Api;

namespace medicalInformationSystem.Models.Api;

public class InspectionConsultationModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime CreateTime { get; set; }
    
    public Guid InspectionId { get; set; }
    
    public SpecialityModel Speciality { get; set; }
    
    public InspectionConsultationModel RootComment { get; set; }
    
    public Int32 CommentsNumber { get; set; }
}