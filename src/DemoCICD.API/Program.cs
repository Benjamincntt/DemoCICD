using DemoCICD.Application.DependencyInjection.Extensions;
using DemoCICD.Persistence.DependencyInjection.Extensions;
using DemoCICD.Persistence.DependencyInjection.Options;
using DemoCICD.Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging
    .ClearProviders()
    .AddSerilog();

builder.Host.UseSerilog();

// Add configuration
builder.Services.AddConfigureMediatR();
builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
builder.Services.AddSqlConfiguration();
builder.Services.AddRepositoryBaseConfiguration();
builder.Services.AddConfigurationAutoMapper();

// Api
builder
    .Services
    .AddControllers()
    .AddApplicationPart(AssemblyReference.Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();