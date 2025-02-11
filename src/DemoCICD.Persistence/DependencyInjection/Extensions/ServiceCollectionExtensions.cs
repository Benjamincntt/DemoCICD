using DemoCICD.Domain.Abstractions;
using DemoCICD.Domain.Abstractions.Repository;
using DemoCICD.Domain.Entities.Identity;
using DemoCICD.Persistence.DependencyInjection.Options;
using DemoCICD.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DemoCICD.Persistence.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSqlConfiguration(this IServiceCollection services)
    {
        services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, builder) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();
            builder
                .EnableSensitiveDataLogging()
                .EnableSensitiveDataLogging()
                .UseLazyLoadingProxies()
                .UseSqlServer(
                    configuration.GetConnectionString("ConnectionStrings"),
                    optionsBuilder => optionsBuilder.ExecutionStrategy(
                            dependencies => new SqlServerRetryingExecutionStrategy(
                                dependencies,
                                options.CurrentValue.MaxRetryCount,
                                options.CurrentValue.MaxRetryDelay,
                                options.CurrentValue.ErrorNumbersToAdd))
                        .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
        });

        services.AddIdentityCore<AppUser>()
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            options.Lockout.MaxFailedAccessAttempts = 3;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });
    }

    public static void AddRepositoryBaseConfiguration(this IServiceCollection services)
    {
        services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork))
            .AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
    }

    public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptions(this IServiceCollection services,
        IConfigurationSection section)
    {
        return services
            .AddOptions<SqlServerRetryOptions>()
            .Bind(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}