using System.Security.Cryptography;
using medicalInformationSystem.Data;
using medicalInformationSystem.Entities;
using medicalInformationSystem.Mappers;
using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Repositorories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using BCrypt.Net;
using medicalInformationSystem.Configurations;
using medicalInformationSystem.Services.Impls;

namespace medicalInformationSystem.Repositorories.Impls;

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

    public Task<Doctor?> GetDoctorById(Guid doctorId)
    {
        throw new NotImplementedException();
    }

    public Task AddDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
    }
}