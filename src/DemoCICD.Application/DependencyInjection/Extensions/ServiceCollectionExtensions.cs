using DemoCICD.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCICD.Application.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSqlConfiguration(this IServiceCollection services)
    {
        services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, builder) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var options = provider.GetRequiredService<IOptionMonitor<SqlServerRetryOptions>>();
        });
    }

    public static IServiceCollection AddConfigureMediatR(this IServiceCollection services)
    {
        return services.AddMediatR(
                cfg =>
                    cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddValidatorsFromAssembly(Contract.AssemblyReference.Assembly, includeInternalTypes: true);
    }
}