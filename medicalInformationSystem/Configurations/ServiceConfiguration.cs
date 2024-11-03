using medicalInformationSystem.Core.Repositories.Impls;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Impls;
using medicalInformationSystem.Core.Services.Interfaces;

namespace medicalInformationSystem.Configurations;

public static class ServiceConfiguration
{
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IIcd10Repository, Icd10Repository>();
        services.AddScoped<ISpecialityRepository, SpecialityRepository>(); 
        
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProfileService, ProfileService>(); 
        services.AddScoped<IIcd10Service, Icd10Service>(); 
    }
}