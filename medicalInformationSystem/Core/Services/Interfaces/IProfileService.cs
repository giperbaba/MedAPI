using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;

namespace medicalInformationSystem.Core.Services.Interfaces;

public interface IProfileService
{
    Task<DoctorModel> GetProfile(Guid doctorId);

    Task<ResponseModel> EditProfile(DoctorEditModel doctorEditModel);
}