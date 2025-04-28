using ComputergyAPI.Contexts;
using ComputergyAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ComputergyAPI.Interfaces;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using Serilog;
using ComputergyAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Computergy API",
        Description = "An API for managing an E-Commerce for computer-related resources for Computergy store. This API provides endpoints for managing products, orders, customers, and inventory. It is designed to be scalable, secure, and easy to integrate with third-party services.",
        TermsOfService = new Uri("https://Computergy.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Support Team",
            Email = "support@computergy.com",
            Url = new Uri("https://computergy.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // Add XML comments if you're using them
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// Setup Log file for Debug/Trace output (low-level runtime logs)
var debugLogFilePath = "Logs/debug-output.txt";
Directory.CreateDirectory("Logs");
var debugLogFileStream = new FileStream(debugLogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
var debugLogWriter = new StreamWriter(debugLogFileStream) { AutoFlush = true };
Trace.Listeners.Clear();
Trace.Listeners.Add(new TextWriterTraceListener(debugLogWriter));

// Configure Serilog (normal app logs)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Log immediately after setting Logger
Log.Information("***** Application is starting (before Build) *****");

builder.Host.UseSerilog();

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Database Context
builder.Services.AddDbContext<ComputergyDbContext>(option => option.UseSqlServer("Data Source=DESKTOP-E4L6533\\SQLEXPRESS;Initial Catalog=ComputergyDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

// Add Authentication and Authorization with JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // for development
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:IssuerIP"],
            ValidAudience = builder.Configuration["JWT:AudienceIP"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero // No extra time allowed after expiration
        };
    });

builder.Services.AddAuthorization();

// Add Scoped Services
builder.Services.AddScoped<IAuthanication, AuthanicationService>();
builder.Services.AddScoped<IProducts, ProductsService>();
builder.Services.AddSingleton<TokenProvider>();

// After adding services, log them
foreach (var service in builder.Services)
{
    Log.Information($"Service Registered: {service.ServiceType.FullName} -> {service.ImplementationType?.FullName}");
}

var app = builder.Build();

// Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionLoggingMiddleware>();

app.MapControllers();

// Optional final log (app started)
Log.Information("***** Application Built and Running *****");

// Start the app
try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Error($"An Error Was Occured While Start Up {ex.Message}");
}
finally
{
    Log.CloseAndFlush(); // VERY important to ensure logs are written!
}
//