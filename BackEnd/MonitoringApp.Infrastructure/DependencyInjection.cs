using Microsoft.EntityFrameworkCore;
using MonitoringApp.Application.Interfaces;
using MonitoringApp.Infrastructure.Logging;
using MonitoringApp.Infrastructure.Persistence;
using MonitoringApp.Infrastructure.Repositories;
using MonitoringApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;



namespace MonitoringApp.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			// Registrar DbContext con EF Core en memoria
			services.AddDbContext<MonitoringAppDbContext>(options =>
				options.UseInMemoryDatabase("MonitoringAppDb"));

			// Registrar Repositorios
			services.AddScoped<IPlatformStatusRepository, PlatformStatusRepository>();

			// Registrar Servicios
            services.AddScoped<IHttpClientService, HttpClientService>();
            services.AddScoped<IPlatformStatusService, PlatformStatusService>();



            // Registrar Logging genérico
            services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

			// Registrar AutoMapper 
			services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            // Registrar HttpClient
            services.AddHttpClient();



            return services;
		}
	}
}
