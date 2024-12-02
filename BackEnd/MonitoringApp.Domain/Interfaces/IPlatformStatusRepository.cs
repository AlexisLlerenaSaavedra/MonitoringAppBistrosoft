using MonitoringApp.Domain.Entities;

namespace MonitoringApp.Application.Interfaces
{
	public interface IPlatformStatusRepository
	{
        Task AddPlatformStatusesAsync(IEnumerable<PlatformStatus> platformStatuses);
        Task<List<PlatformStatus>> GetAllPlatformStatusesAsync();



    }
}
