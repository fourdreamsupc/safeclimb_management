using Mapping;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Contexts;
using Microsoft.OpenApi.Models;
using Shared.Domain.Repositories;
using Shared.Persistence.Repositories;
using Reviews.Domain.Services;
using Reviews.Domain.Repositories;
using Reviews.Services;
using Reviews.Persistence.Repositories;
using Activities.Persistence.Repositories;
using Activities.Domain.Repositories;
using Activities.Domain.Services;
using Activities.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
        
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Management Context - SafeClimb API",
        Description = "Management Context including Services and Hired Services",
        TermsOfService = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/"),
        Contact = new OpenApiContact
        {
            Name = "SafeClimb.studio",
            Url = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/")
        },
        License = new OpenApiLicense
        {
            Name = "SafeClimb Resources License",
            Url = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/")
        }
    });
    options.EnableAnnotations();
});

// Add Database Connection

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = builder.Configuration.GetConnectionString("AzureDbConnection");
// Database Connection with Standard Level for Information and Errors

builder.Services.AddDbContext<AppDbContext>(options => 
{   options.UseMySQL(connectionString);
    options.LogTo(Console.WriteLine);
});

// Add lowercase routes

builder.Services.AddRouting(options => 
options.LowercaseUrls = true);

builder.Services.AddScoped<IAgencyReviewService, AgencyReviewService>();
builder.Services.AddScoped<IAgencyReviewRepository, AgencyReviewsRepository>();

builder.Services.AddScoped<IServiceReviewRepository, ServiceReviewsRepository>();
builder.Services.AddScoped<IServiceReviewService, ServiceReviewService>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
