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
using medicalInformationSystem.Services.Impls;

namespace medicalInformationSystem.Repositorories.Impls;

public class DoctorRepository(MedicalDataContext context, TokenService tokenService) : IDoctorRepository
{

    public async Task<TokenModel> Register(DoctorRegisterModel doctor, string hashPassword)
    {
        if (await GetDoctorByEmail(doctor.Email) is null)
        {
            var newDoctor = DoctorMapper.Map(doctor, BCrypt.Net.BCrypt.HashPassword(hashPassword));
            await context.Doctors.AddAsync(newDoctor);
            await context.SaveChangesAsync();
            //TODO: return token
            var token =  tokenService.GenerateAccessToken(newDoctor);
            var tokenModel = new TokenModel(token);
            
            return tokenModel;
        }
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