using DemoCICD.Application;
using DemoCICD.Application.Behaviors;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration
builder.Services.AddMediatR(option => option.RegisterServicesFromAssembly(AssemblyReference.Assembly));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddValidatorsFromAssembly(
    AssemblyReference.Assembly,
    includeInternalTypes: true);
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();