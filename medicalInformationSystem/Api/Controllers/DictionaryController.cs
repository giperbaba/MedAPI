using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Api.Models.Response;
using medicalInformationSystem.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace medicalInformationSystem.Api.Controllers;

[ApiController]
[Route("api/dictionary")]
public class DictionaryController(IDictionaryService dictionaryService)
{
    [HttpGet("speciality")]
    [SwaggerOperation(Summary = "Register new user")]
    public async Task<SpecialitiesPagedListModel> GetSpecialities([FromQuery] QueryParameters queryParameters)
    {
        return await dictionaryService.GetSpecialitiesPagedList(queryParameters);
    }
    
    [HttpGet("icd10")]
    [SwaggerOperation(Summary = "Search for diagnoses in ICD-10 dictionary")]
    public async Task<Icd10SearchModel> SearchDiagnosis([FromQuery] QueryParameters queryParameters)
    {
        return await dictionaryService.GetIcd10PagedList(queryParameters);
    }
    
    
}