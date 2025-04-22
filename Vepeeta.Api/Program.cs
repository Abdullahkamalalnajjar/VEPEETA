using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using TechTalk.SpecFlow.Analytics.UserId;
using Vepeeta.Api.Configurations.Swagger;
using Vepeeta.Core;
using Vepeeta.Core.Bases;
using Vepeeta.Core.MidelWare;
using Vepeeta.Data;
using Vepeeta.Infrastructure.DataSeeding;
using Vepeeta.infrustructure;
using Vepeeta.infrustructure.DbContext;
using Vepeeta.Service;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();
builder.Services.AddScoped<ResponseHandler>();
#region Dependencies
builder.Services.AddCoreDependencies()
    .AddServiceDependencies()
    .AddInfrustructureDependencies()
    .AddServiceRegisteration(builder.Configuration)
    .AddDataDependencies(builder.Configuration);
#endregion

#region ConcationString
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion

builder.Services.AddScoped<IFileService, FileService>();



var app = builder.Build();
#region Update
//update database
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{
    var DbContext = services.GetRequiredService<ApplicationDbContext>();
    await DbContext.Database.MigrateAsync();

    // Add seeding after successful migration
    await ContextSeed.SeedAsync(DbContext);
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogInformation("Database seeded successfully");
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error during Apply migration or seeding");
}
#endregion

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();//for IMGI IN WWWWROOT
//}

#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
