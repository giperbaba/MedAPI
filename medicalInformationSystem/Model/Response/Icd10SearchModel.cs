using medicalInformationSystem.Model.Api;

namespace medicalInformationSystem.Model.Response;

public class Icd10SearchModel
{
    public List<Icd10RecordModel>? Records { get; set; }
    
    public PageInfoModel Pagination { get; set; }
}