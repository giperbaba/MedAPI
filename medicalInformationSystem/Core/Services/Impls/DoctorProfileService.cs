using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Exceptions;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;

namespace medicalInformationSystem.Core.Services.Impls;

public class DoctorProfileService(
    IDoctorRepository doctorRepository): IProfileService
{
    public async Task<ResponseModel> EditProfile(DoctorEditModel doctorEditModel)
    {
        var doctorFromDatabase = await doctorRepository.GetDoctorByEmail(doctorEditModel.Email);

        if (doctorFromDatabase is null)
        {
            throw new ProfileNotFoundException(ErrorConstants.ProfileNotFoundError);
        }
        
        doctorFromDatabase.Name = doctorEditModel.Name;
        doctorFromDatabase.Birthday = doctorEditModel.Birthday.ToUniversalTime();
        doctorFromDatabase.Phone = doctorEditModel.Phone;
        doctorFromDatabase.Gender = doctorEditModel.Gender;
        
        await doctorRepository.Edit(doctorFromDatabase);
        
        return new ResponseModel(null, "Edit successful");
    }

    public async Task<DoctorModel> GetProfile(Guid doctorId)
    {
        var doctor = await doctorRepository.GetDoctorById(doctorId);
                          
        if (doctor is null)
        {
            throw new ProfileNotFoundException(ErrorConstants.ProfileNotFoundError);
        }

        return DoctorMapper.MapFromEntityToDoctorModel(doctor);
    }
}