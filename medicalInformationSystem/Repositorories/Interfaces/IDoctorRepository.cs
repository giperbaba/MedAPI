using medicalInformationSystem.Entities;
using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace medicalInformationSystem.Repositorories.Interfaces;

public interface IDoctorRepository
{
    public Task<TokenModel> Register(DoctorRegisterModel doctor, string hashPassword);
    
    public Task<Doctor?> GetDoctorByEmail (string email);
    public Task<Doctor?> GetDoctorById(Guid doctorId);
    
    public Task AddDoctor(Doctor doctor);
}