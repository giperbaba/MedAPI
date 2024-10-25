using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Model.Request;

public class ConsultationCreateModel
{
    public ConsultationCreateModel(InspectionCommentCreateModel comment)
    {
        Comment = comment;
    }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid SpecialityId { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public InspectionCommentCreateModel Comment { get; set; }
}