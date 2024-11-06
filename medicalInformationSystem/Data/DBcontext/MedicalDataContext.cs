using medicalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Data.DBcontext;

public partial class MedicalDataContext : DbContext
{
    public MedicalDataContext()
    {
    }

    public MedicalDataContext(DbContextOptions<MedicalDataContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Speciality?> Specialities { get; set; } = null!;
    public DbSet<Icd10> Icd10s { get; set; } = null!;
    
    public DbSet<Patient> Patients { get; set; } = null!;
}
