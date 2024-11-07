using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Data.Entities;

[Table("Comment")]
public class Comment
{
    [Column("id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid? Id { get; set; }
    
    [Column("create_time")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public DateTime? CreateTime { get; set; }
    
    [Column("modified_date")]
    public DateTime? ModifiedDate { get; set; }
    
    [Column("content")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = ErrorConstants.CommentLengthError)]
    public string Content { get; set; }
    
    [Column("parent_comment_id")]
    public Guid? ParentCommentId { get; set; }
    public Comment ParentComment { get; set; }
    
    [Column("author_id")]
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid AuthorId { get; set; }
    public Doctor Author { get; set; }
    
    [Column("consultation_id")]
    public Guid ConsultationId { get; set; }
    public Consultation Consultation { get; set; }
    
    public ICollection<Comment> Childrens { get; set; }
}