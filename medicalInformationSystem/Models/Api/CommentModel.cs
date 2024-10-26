using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Models.Api;

public class CommentModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid? Id { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime? CreateTime { get; set; }
    
    public DateTime? ModifiedDate { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.CommentLengthError)]
    public string Content { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid AuthorId { get; set; }
    
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [MinLength(1, ErrorMessage = ErrorConstants.AuthorNameLengthError)]
    public string Author { get; set; }
    
    public Guid? ParentId { get; set; }
}