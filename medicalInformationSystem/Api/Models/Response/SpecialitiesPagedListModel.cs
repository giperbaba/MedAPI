using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Models.Api;

namespace medicalInformationSystem.Api.Models.Response;

public class SpecialitiesPagedListModel
{
    public List<SpecialityModel> Specialties { get; set; } = new List<SpecialityModel>();
    public PageInfoModel Pagination { get; set; } 
}