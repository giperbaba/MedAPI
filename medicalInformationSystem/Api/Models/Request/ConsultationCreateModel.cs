using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Models.Request;

namespace medicalInformationSystem.Api.Models.Request;

public class ConsultationCreateModel(InspectionCommentCreateModel comment)
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid SpecialityId { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public InspectionCommentCreateModel Comment { get; set; } = comment;
}