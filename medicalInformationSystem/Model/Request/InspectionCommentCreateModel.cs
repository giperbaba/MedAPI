using System.ComponentModel.DataAnnotations;

namespace medicalInformationSystem.Model.Request;

public class InspectionCommentCreateModel
{
    [StringLength(1000, MinimumLength = 1, ErrorMessage = "Inspection Comment Name must be between 1 and 1000 characters.")]
    [Required(ErrorMessage = "Inspection Comment Name is required.")]
    public required string Content { get; set; }
}