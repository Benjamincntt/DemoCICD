using Microsoft.Extensions.DependencyInjection;

namespace DemoCICD.Application.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddConfigureMediatR(this IServiceCollection services)
	{
		return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
	}
}
