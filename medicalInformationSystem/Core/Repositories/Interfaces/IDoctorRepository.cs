using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface IDoctorRepository
{
    public Task Add(Doctor doctor);
    
    public Task Edit(Doctor doctor);
    
    public Task<Doctor?> GetDoctorByEmail (string email);
    public Task<Doctor?> GetDoctorById(Guid doctorId);
    
}