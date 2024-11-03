using medicalInformationSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MedicalDataContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection")));
    }
}