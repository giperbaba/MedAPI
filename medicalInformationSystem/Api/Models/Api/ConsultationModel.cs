using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Models.Api;

namespace medicalInformationSystem.Api.Models.Api;

public class ConsultationModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    private DateTime CreateTime { get; set; }

    public Guid InspectionId { get; set; }

    public SpecialityModel Speciality { get; set; }

    public List<CommentModel> Comments { get; set; }
}