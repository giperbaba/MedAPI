using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Api.Models.Response;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Exceptions;

namespace medicalInformationSystem.Core.Services.Impls;

public class DictionaryService(ISpecialityRepository specialityRepository, IIcd10Repository icd10Repository): IDictionaryService
{ 
    public async Task<SpecialitiesPagedListModel> GetSpecialitiesPagedList(QueryParameters queryParameters)
    {
        int countSpecialities = await specialityRepository.GetLength();
        
        if (queryParameters.GetSkip() > countSpecialities || queryParameters.Page > countSpecialities)
            throw new InvalidValuePageException(ErrorConstants.InvalidValuePageError);
        
        
        var specialitiesPagedListModel = new SpecialitiesPagedListModel
        {
            Specialties = await GetSpecialities(queryParameters),
            Pagination = await GetPageInfo(queryParameters, countSpecialities)
        };

        return specialitiesPagedListModel;
    }

    public async Task<Icd10SearchModel> GetIcd10PagedList(QueryParameters queryParameters)
    {
        int countIcd10 = await icd10Repository.GetLength();

        if (queryParameters.GetSkip() > countIcd10 || queryParameters.Page > countIcd10)
            throw new InvalidValuePageException(ErrorConstants.InvalidValuePageError);

        var icd10PagedListModel = new Icd10SearchModel
        {
            Records = await GetIcd10Records(queryParameters),
            Pagination = await GetPageInfo(queryParameters, countIcd10)
        };

        return icd10PagedListModel;
    }

    private async Task<List<SpecialityModel>> GetSpecialities(QueryParameters queryParameters)
    {
        var listSpecialityEntities = await specialityRepository.GetListSpeciality(queryParameters.GetSkip(),queryParameters.Size, queryParameters.Name);
        List<SpecialityModel> specialities = new List<SpecialityModel>();
        foreach (var speciality in listSpecialityEntities)
        {
            specialities.Add(SpecialityMapper.MapFromEntityToModel(speciality));
        }

        return specialities;
    }

    public async Task<List<Icd10RecordModel>> GetIcd10Roots()
    {
        List<Icd10> icd10RootsEntities = await icd10Repository.GetIcd10Roots();
        List<Icd10RecordModel> icd10RecordModels = new List<Icd10RecordModel>();

        foreach (var entity in icd10RootsEntities)
        {
            icd10RecordModels.Add(Icd10Mapper.MapFromEntityToModel(entity));
        }

        return icd10RecordModels;
    }
    
    private async Task<List<Icd10RecordModel>> GetIcd10Records(QueryParameters queryParameters)
    {
        var listIcd10Entities = await icd10Repository.GetListIcd10(queryParameters.GetSkip(), queryParameters.Size, queryParameters.Name);
        List<Icd10RecordModel> icd10Models = new List<Icd10RecordModel>();

        foreach (var icd10 in listIcd10Entities)
        {
            icd10Models.Add(Icd10Mapper.MapFromEntityToModel(icd10));
        }
        return icd10Models;
    }

    private Task<PageInfoModel> GetPageInfo(QueryParameters queryParameters, int countSpecialities)
    {
        int countPages = (int)Math.Ceiling((double)countSpecialities / queryParameters.Size);
        var pageInfo = new PageInfoModel
        {
            Size = queryParameters.Size,
            Count = countPages,
            Current = queryParameters.Page
        };
        return Task.FromResult(pageInfo);
    }
}