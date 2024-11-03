using medicalInformationSystem.Api.Models.Response;
using medicalInformationSystem.Models.Api;

namespace medicalInformationSystem.Models.Response;

public class Icd10SearchModel
{
    public List<Icd10RecordModel>? Records { get; set; }
    
    public PageInfoModel Pagination { get; set; }
}