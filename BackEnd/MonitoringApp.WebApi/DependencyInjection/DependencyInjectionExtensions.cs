using MediatR;
using MonitoringApp.Application.Queries.GetPlatformStatuses;
using MonitoringApp.Infrastructure;

namespace MonitoringApp.WebApi.DependencyInjection
{
	public static class DependencyInjectionExtensions
	{
		public static IServiceCollection AddWebApiServices(this IServiceCollection services)
		{
			// Registrar servicios de infraestructura
			services.AddInfrastructure();

            // Registrar MediatR con el ensamblado de la capa de aplicación
            services.AddMediatR(typeof(GetPlatformStatusesQueryHandler).Assembly);

            // Otros servicios
            services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			return services;
		}
	}
}
