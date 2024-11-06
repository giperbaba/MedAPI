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
    public async Task<SpecialitiesPagedListModel> GetSpecialitiesPagedList(QueryParametersModel queryParametersModel)
    {
        int countSpecialities = await specialityRepository.GetLength();
        
        if (queryParametersModel.GetSkip() > countSpecialities || queryParametersModel.Page > countSpecialities)
            throw new InvalidValuePageException(ErrorConstants.InvalidValuePageError);
        
        
        var specialitiesPagedListModel = new SpecialitiesPagedListModel
        {
            Specialties = await GetSpecialities(queryParametersModel),
            Pagination = await GetPageInfo(queryParametersModel, countSpecialities)
        };

        return specialitiesPagedListModel;
    }

    public async Task<Icd10SearchModel> GetIcd10PagedList(QueryParametersModel queryParametersModel)
    {
        int countIcd10 = await icd10Repository.GetLength();

        if (queryParametersModel.GetSkip() > countIcd10 || queryParametersModel.Page > countIcd10)
            throw new InvalidValuePageException(ErrorConstants.InvalidValuePageError);

        var icd10PagedListModel = new Icd10SearchModel
        {
            Records = await GetIcd10Records(queryParametersModel),
            Pagination = await GetPageInfo(queryParametersModel, countIcd10)
        };

        return icd10PagedListModel;
    }

    private async Task<List<SpecialityModel>> GetSpecialities(QueryParametersModel queryParametersModel)
    {
        var listSpecialityEntities = await specialityRepository.GetListSpeciality(queryParametersModel.GetSkip(),queryParametersModel.Size, queryParametersModel.Name);
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
    
    private async Task<List<Icd10RecordModel>> GetIcd10Records(QueryParametersModel queryParametersModel)
    {
        var listIcd10Entities = await icd10Repository.GetListIcd10(queryParametersModel.GetSkip(), queryParametersModel.Size, queryParametersModel.Name);
        List<Icd10RecordModel> icd10Models = new List<Icd10RecordModel>();

        foreach (var icd10 in listIcd10Entities)
        {
            icd10Models.Add(Icd10Mapper.MapFromEntityToModel(icd10));
        }
        return icd10Models;
    }

    private Task<PageInfoModel> GetPageInfo(QueryParametersModel queryParametersModel, int countSpecialities)
    {
        int countPages = (int)Math.Ceiling((double)countSpecialities / queryParametersModel.Size);
        var pageInfo = new PageInfoModel
        {
            Size = queryParametersModel.Size,
            Count = countPages,
            Current = queryParametersModel.Page
        };
        return Task.FromResult(pageInfo);
    }
}