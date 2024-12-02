using Microsoft.EntityFrameworkCore;
using MonitoringApp.Application.Interfaces;
using MonitoringApp.Domain.Entities;
using MonitoringApp.Infrastructure.Persistence;
using System.Text.Json;

namespace MonitoringApp.Infrastructure.Repositories
{
    public class PlatformStatusRepository : IPlatformStatusRepository
    {
        private readonly MonitoringAppDbContext _context;

        public PlatformStatusRepository(MonitoringAppDbContext context)
        {
            _context = context;
        }

        public async Task AddPlatformStatusesAsync(IEnumerable<PlatformStatus> platformStatuses)
        {
            _context.PlatformStatuses.AddRange(platformStatuses);
            await _context.SaveChangesAsync();
        }

        

        public async Task<List<PlatformStatus>> GetAllPlatformStatusesAsync()
        {
            return await _context.PlatformStatuses.ToListAsync();
        }
    }
}
