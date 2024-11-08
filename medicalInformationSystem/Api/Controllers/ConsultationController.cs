using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace medicalInformationSystem.Api.Controllers;

[ApiController]
[Route("api/consultation")]
public class ConsultationController(IConsultationService consultationService): BaseController
{
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.ConsultationGet)]
    [Authorize]
    public async Task<ConsultationModel> GetSpecialities(Guid id)
    {
        return await consultationService.GetConcreteConsultation(id);
    }
}