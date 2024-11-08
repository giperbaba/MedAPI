using System.ComponentModel.DataAnnotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Api.Models.Request;

public class InspectionSearchModel
{
    [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
    public Guid Id { get; set; } 
    
    public string Request { get; set; } 
}