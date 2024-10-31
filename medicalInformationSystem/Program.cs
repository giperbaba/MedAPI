using medicalInformationSystem.Configurations;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Data;
using medicalInformationSystem.Repositories.Impls;
using medicalInformationSystem.Repositories.Interfaces;
using medicalInformationSystem.Services.Interfaces;
using medicalInformationSystem.Services.Impls;
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
services.AddScoped<IAuthService, AuthService>();

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
app.Run();