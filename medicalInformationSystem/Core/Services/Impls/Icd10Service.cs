using System.Text.Json;
using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Services.Impls;

public class Icd10Service(IIcd10Repository icd10Repository) : IIcd10Service
{
    public async Task UploadIcd10Json()
    {
        if (icd10Repository.IsTableIcd10Empty())
        {
            var jsonData = await File.ReadAllTextAsync("/Users/giperbaba/RiderProjects/webNET-2024_aspnet_1/medicalInformationSystem/Data/Icd10codes/icd10codes.json");
            var icd10Nodes = JsonSerializer.Deserialize<List<Icd10Model>>(jsonData);

            foreach (var icd10Node in icd10Nodes)
            {
                await AddToDb(icd10Node, Guid.NewGuid(), null);
            }

            foreach (var icd10Node in icd10Nodes)
            {
                if (icd10Node.idParent != null)
                {
                    Icd10 currentNode = await icd10Repository.GetByIdInt(icd10Node.idInt.ToString());
                    Icd10 parentNode = await icd10Repository.GetByIdInt(icd10Node.idParent);
                    Guid? parentGuid = parentNode.IdGuid;

                    await icd10Repository.UpdateGuidParent(currentNode.IdGuid, parentGuid);
                }
            }
        }
    }
    public async Task AddToDb(Icd10Model currentIcd10Node, Guid idGuid, Guid? parentGuid)
    {
        currentIcd10Node.idGuid = idGuid;
        Icd10 icd10Entity = Icd10Mapper.MapFromModelToEntity(currentIcd10Node, idGuid, parentGuid);

        await icd10Repository.Add(icd10Entity);
    }
}