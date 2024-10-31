using medicalInformationSystem.Data;
using medicalInformationSystem.Entities;
using medicalInformationSystem.Mappers;
using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Repositories.Impls;

public class DoctorRepository(MedicalDataContext context) : IDoctorRepository
{

    public async Task Add(Doctor doctor)
    {
        await context.Doctors.AddAsync(doctor);
        await context.SaveChangesAsync();
    }

    public async Task<Doctor?> GetDoctorByEmail(string email)
    {
        return await context.Doctors.FirstOrDefaultAsync(doctor => doctor.Email == email);
    }

    public async Task<Doctor?> GetDoctorById(Guid doctorId)
    {
        return await context.Doctors.FirstOrDefaultAsync(doctor => doctor.Id == doctorId);
    }
    
    
}