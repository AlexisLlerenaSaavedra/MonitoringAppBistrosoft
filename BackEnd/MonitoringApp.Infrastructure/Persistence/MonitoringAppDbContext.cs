using Microsoft.EntityFrameworkCore;
using MonitoringApp.Domain.Entities;

namespace MonitoringApp.Infrastructure.Persistence
{
	public class MonitoringAppDbContext : DbContext
	{
		public MonitoringAppDbContext(DbContextOptions<MonitoringAppDbContext> options)
			: base(options) { }

		public DbSet<PlatformStatus> PlatformStatuses { get; set; }
	}


}
