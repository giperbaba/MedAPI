using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Api.Models.Request;

public class CommentCreateModel
{
    public CommentCreateModel(string content)
    {
        Content = content;
    }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.CommentLengthError)]
    public string Content { get; set; }
    
    public Guid ParentId { get; set; }
    
}