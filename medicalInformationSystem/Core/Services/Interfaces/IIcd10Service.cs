using medicalInformationSystem.Api.Models.Api;

namespace medicalInformationSystem.Core.Services.Interfaces;

public interface IIcd10Service
{
    public Task UploadIcd10Json();
    public Task AddToDb(Icd10Model currentIcd10Node, Guid? idGuid, Guid? parentGuid);
}