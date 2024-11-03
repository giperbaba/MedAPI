using medicalInformationSystem.Configurations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Repositories.Impls;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Impls;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddDbContext<MedicalDataContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection")));

services.AddScoped<IDoctorRepository, DoctorRepository>();
services.AddScoped<ITokenService, TokenService>();
services.AddScoped<ISpecialityRepository, SpecialityRepository>(); 
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IIcd10Repository, Icd10Repository>(); 
services.AddScoped<IIcd10Service, Icd10Service>(); 


services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddHttpContextAccessor(); 

services.AddSingleton<JwtConfiguration>();
JwtConfiguration.AddApiAuthentication(services, services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>());

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Medical Information System API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical Information System API v1");
    });
}

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
});

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var icd10Service = scope.ServiceProvider.GetRequiredService<IIcd10Service>();
    await icd10Service.UploadIcd10Json(); 
}
app.Run();