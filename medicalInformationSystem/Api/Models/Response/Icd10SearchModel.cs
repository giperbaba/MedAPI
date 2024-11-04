using medicalInformationSystem.Api.Models.Api;

namespace medicalInformationSystem.Api.Models.Response;

public class Icd10SearchModel
{
    public List<Icd10RecordModel>? Records { get; set; }
    
    public PageInfoModel Pagination { get; set; }
}