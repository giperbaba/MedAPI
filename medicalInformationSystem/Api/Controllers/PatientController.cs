using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Api.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController(IPatientService patientService) : BaseController
{
    [HttpPost]
    [SwaggerOperation(Summary = SwaggerOperationConstants.PatientCreate)]
    [Authorize]
    public async Task<Guid> Register(PatientRegisterModel patientRegisterModel)
    {
        Guid doctorIdWhoRegistered = GetDoctorId();
        Guid patientId = await patientService.Register(patientRegisterModel, doctorIdWhoRegistered);
        return patientId;
    }

    [HttpPost("{id}/inspections")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.PatientCreateInspection)]
    [Authorize]
    public async Task<Guid> CreateInspection(Guid id, InspectionCreateModel inspectionCreateModel)
    {
        Guid doctorIdWhoRegistered = GetDoctorId();
        Guid inspectionId = await patientService.CreateInspection(inspectionCreateModel, doctorIdWhoRegistered, id);
        return inspectionId;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.PatientGetCard)]
    [Authorize]
    public async Task<PatientModel> GetPatientCard(Guid id)
    {
        return await patientService.GetPatientById(id);
    }
    
    [HttpGet("{id}/inspections/search")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.PatientSearchInspection)]
    [Authorize]
    public async Task<ICollection<InspectionShortModel>> SearchInspections(Guid id, [FromQuery] string request = "")
    {
        return await patientService.SearchInspections(id, request);
    }
}