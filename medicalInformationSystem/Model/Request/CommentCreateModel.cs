using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Model.Request;

public class CommentCreateModel
{
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.CommentLengthError)]
    public string Content { get; set; }
    
    public Guid ParentId { get; set; }
    
}