using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace medicalInformationSystem.Api.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController(IPatientService patientService): BaseController
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create new patient")]
    [Authorize]
    public async Task<Guid> Register(PatientRegisterModel patientRegisterModel)
    {
        Guid doctorIdWhoRegistered = GetDoctorId();
        Guid patientId = await patientService.Register(patientRegisterModel, doctorIdWhoRegistered);
        return patientId;
    }

    [HttpPost("{id}/inspections")]
    [SwaggerOperation(Summary = "Create inspection for specified patient")]
    [Authorize]
    public async Task<Guid> CreateInspection(Guid id, InspectionCreateModel inspectionCreateModel)
    {
        Guid doctorIdWhoRegistered = GetDoctorId();
        Guid inspectionId = await patientService.CreateInspection(inspectionCreateModel, doctorIdWhoRegistered, id);
        return inspectionId;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get patient card")]
    [Authorize]
    public async Task<PatientModel> GetPatientCard(Guid id)
    {
        return await patientService.GetPatientById(id);
    }
}