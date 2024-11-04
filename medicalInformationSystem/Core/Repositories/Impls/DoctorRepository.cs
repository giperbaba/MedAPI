#nullable enable
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data;
using medicalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class DoctorRepository(MedicalDataContext context) : IDoctorRepository
{

    public async Task Add(Doctor doctor)
    {
        await context.Doctors.AddAsync(doctor);
        await context.SaveChangesAsync();
    }

    public async Task Edit(Doctor doctor)
    {
        context.Doctors.Attach(doctor).State = EntityState.Modified;
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