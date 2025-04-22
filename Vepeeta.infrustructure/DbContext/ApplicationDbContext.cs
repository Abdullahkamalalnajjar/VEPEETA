using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vepeeta.Data.Entity;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.Identity.Clinics;
using Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services;
using Vepeeta.Data.Entity.Identity.Doctor;
using Vepeeta.Data.Entity.MedicalServices;
using Vepeeta.Data.Entity.MobileVan;
using Vepeeta.Data.Entity.MobileVan.MobileVanService;

namespace Vepeeta.infrustructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);



            modelBuilder.Entity<BaseServices>()
                .HasDiscriminator<string>("ServiceType")
               .HasValue<HealthCareService>("HealthCare")
               .HasValue<Surgery>("Surgery")
               .HasValue<GroomingBird>("GroomingBird")
               .HasValue<GroomingCat>("GroomingCat")
               .HasValue<GroomingDog>("GroomingDog")
               .HasValue<LaboratoryTests>("LaboratoryTests")
               .HasValue<SpecialtyServices>("SpecialtyServices")
               .HasValue<Vaccinations>("Vaccinations")
               .HasValue<Boarding>("Boarding")
               .HasValue<VanHealthCareService>("VanHealthCare");

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<ClinicServices> ClinicServices { get; set; }
        public DbSet<BaseServices> Services { get; set; }
        public DbSet<ClincsImage> ClincsImages { get; set; }
        public DbSet<Van> Vans { get; set; }
        public DbSet<VanServices> VanServices { get; set; }
        public DbSet<VanWorkingHour> VanWorkingHours { get; set; }
        public DbSet<Rateing> Rateing { get; set; }
        public DbSet<DoctorService> DoctorServices { get; set; }
        public DbSet<MedicalService> MedicalServices { get; set; }

    }
}
