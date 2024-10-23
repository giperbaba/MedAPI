using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Model.Request;

public class InspectionCommentCreateModel
{
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.CommentLengthError)]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public required string Content { get; set; }
}