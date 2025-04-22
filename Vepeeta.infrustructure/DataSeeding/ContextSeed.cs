using System.Text.Json;
using Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services;
using Vepeeta.Data.Entity.MedicalServices;
using Vepeeta.Data.Entity.MobileVan.MobileVanService;
using Vepeeta.infrustructure.DbContext;

namespace Vepeeta.Infrastructure.DataSeeding
{
    public class ContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            // Check if data already exists in HealthCareService table
            if (!dbContext.Services.OfType<HealthCareService>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/HealthCeare.json");

                    // Deserialize JSON data to list of HealthCareServiceDto
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new HealthCareService
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding HealthCareService data: {ex.Message}");
                }
            }
            // Check if data already exists in Vaccinations table
            if (!dbContext.Services.OfType<Vaccinations>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/Vaccinations.json");

                    // Deserialize JSON data to list of Vaccinations
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new Vaccinations
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding HealthCareService data: {ex.Message}");
                }
            }
            // Check if data already exists in Surgery table
            if (!dbContext.Services.OfType<Surgery>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/Surgery.json");

                    // Deserialize JSON data to list of Surgery
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var Surgery = services.Select(s => new Surgery
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(Surgery);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding HealthCareService data: {ex.Message}");
                }
            }
            // Check if data already exists in SpecialtyServices table
            if (!dbContext.Services.OfType<SpecialtyServices>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/SpecialtyServices.json");

                    // Deserialize JSON data to list of Vaccinations
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new SpecialtyServices
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding HealthCareService data: {ex.Message}");
                }
            }
            // Check if data already exists in LaboratoryTests table
            if (!dbContext.Services.OfType<LaboratoryTests>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/LaboratoryTests.json");

                    // Deserialize JSON data to list of Vaccinations
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var LaboratoryTests = services.Select(s => new LaboratoryTests
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(LaboratoryTests);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding HealthCareService data: {ex.Message}");
                }
            }
            // Check if data already exists in SpecialtyServices table
            if (!dbContext.Services.OfType<GroomingDog>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/GroomingDog.json");

                    // Deserialize JSON data to list of GroomingDog
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new GroomingDog
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding GroomingDog data: {ex.Message}");
                }
            }
            // Check if data already exists in SpecialtyServices table
            if (!dbContext.Services.OfType<GroomingCat>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/GroomingCat.json");

                    // Deserialize JSON data to list of Vaccinations
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new GroomingCat
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding GroomingCat data: {ex.Message}");
                }
            }
            // Check if data already exists in SpecialtyServices table
            if (!dbContext.Services.OfType<GroomingBird>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/GroomingBird.json");

                    // Deserialize JSON data to list of Vaccinations
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new GroomingBird
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding GroomingBird data: {ex.Message}");
                }
            }
            // Check if data already exists in Boarding table
            if (!dbContext.Services.OfType<Boarding>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/Boarding.json");

                    // Deserialize JSON data to list of Vaccinations
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new Boarding
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding Boarding data: {ex.Message}");
                }
            }
            // Check if data already exists in HealthCareService table
            if (!dbContext.Services.OfType<VanHealthCareService>().Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/HealthCeare.json");

                    // Deserialize JSON data to list of HealthCareServiceDto
                    var services = JsonSerializer.Deserialize<List<ServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        // Map DTOs to HealthCareService entities
                        var healthcareServices = services.Select(s => new VanHealthCareService
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn
                        }).ToList();

                        // Add all services to the context
                        await dbContext.Services.AddRangeAsync(healthcareServices);

                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding HealthCareService data: {ex.Message}");
                }
            }
            // Check if data already exists in Service table
            if (!dbContext.MedicalServices.Any())
            {
                try
                {
                    // Read clinic services data from JSON file
                    var servicesData = File.ReadAllText("../Vepeeta.Data/DataSeed/MedicalServices.json");

                    // Deserialize JSON data to list of HealthCareServiceDto
                    var services = JsonSerializer.Deserialize<List<MedicalServiceDto>>(servicesData);

                    if (services != null && services.Count > 0)
                    {
                        var Services = services.Where(s => !string.IsNullOrEmpty(s.NameEn))
                        .Select(s => new MedicalService
                        {
                            NameEn = s.NameEn,
                            NameAr = s.NameAr,
                            Type = s.Type
                        }).ToList();

                        // Add all services to the context
                        await dbContext.MedicalServices.AddRangeAsync(Services);
                        // Save changes to the database
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during seeding
                    Console.WriteLine($"Error seeding HealthCareService data: {ex.Message}");
                }
            }
        }
    }

    // DTO for reading JSON data
    public class ServiceDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
    public class MedicalServiceDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Type { get; set; }
    }
}