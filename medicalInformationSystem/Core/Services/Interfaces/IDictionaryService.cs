using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Api.Models.Response;

namespace medicalInformationSystem.Core.Services.Interfaces;

public interface IDictionaryService
{
    public Task<SpecialitiesPagedListModel> GetSpecialitiesPagedList(QueryParameters queryParameters);
    public Task<Icd10SearchModel> GetIcd10PagedList(QueryParameters queryParameters);
    public Task<List<Icd10RecordModel>> GetIcd10Roots();
}