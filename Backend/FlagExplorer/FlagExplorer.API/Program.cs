using FlagExplorer.Application.Services;
using FlagExplorer.Domain.Interfaces;
using FlagExplorer.Domain.Settings;
using FlagExplorer.Infrastructure.Externals;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add configuration
var configuration = builder.Configuration;
builder.Services.Configure<ExternalApiSettings>(configuration.GetSection("ExternalApis"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Country API",
        Version = "1.0.0"
    });

    options.MapType<int>(() => new OpenApiSchema { Type = "integer", Format = "int32" });

    // Define components schemas
   // options.SchemaFilter<CustomSchemaFilter>();
});
builder.Services.AddCors();
builder.Services.AddScoped<ICountryExternalClient, CountryExternalClient>();
builder.Services.AddScoped<ICountryService, CountryService>();


builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Country API v1");
    });
}

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
   );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
