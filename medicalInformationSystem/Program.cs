using medicalInformationSystem.Configurations;
using medicalInformationSystem.Configurations.Options;
using medicalInformationSystem.Core.Services.Interfaces;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

DatabaseConfiguration.ConfigureDatabase(services, configuration);

ServiceConfiguration.AddServices(services);

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.AddHttpContextAccessor(); 

services.AddSingleton<JwtConfiguration>();
JwtConfiguration.AddApiAuthentication(services, services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>());

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Medical Information System API", Version = "v1" });
    c.EnableAnnotations();
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


MiddlewareConfiguration.ConfigureMiddleware(app);

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var icd10Service = scope.ServiceProvider.GetRequiredService<IIcd10Service>();
    await icd10Service.UploadIcd10Json(); 
}

app.Run();