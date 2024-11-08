using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Api.Models.Response;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace medicalInformationSystem.Api.Controllers;

[ApiController]
[Route("api/dictionary")]
public class DictionaryController(IDictionaryService dictionaryService)
{
    [HttpGet("speciality")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.DictionaryGetSpecialties)]
    public async Task<SpecialitiesPagedListModel> GetSpecialities([FromQuery] QueryParametersModel queryParametersModel)
    {
        return await dictionaryService.GetSpecialitiesPagedList(queryParametersModel);
    }
    
    [HttpGet("icd10")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.DictionarySearchIcd10Diagnoses)]
    public async Task<Icd10SearchModel> SearchDiagnosis([FromQuery] QueryParametersModel queryParametersModel)
    {
        return await dictionaryService.GetIcd10PagedList(queryParametersModel);
    }

    [HttpGet("icd10/roots")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.DictionaryIcd10Roots)]
    public async Task<List<Icd10RecordModel>> GetIcd10Roots()
    {
        return await dictionaryService.GetIcd10Roots();
    }
}