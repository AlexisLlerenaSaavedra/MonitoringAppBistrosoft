using MonitoringApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringApp.Application.Interfaces
{
    public interface IPlatformStatusService
    {
        Task<List<PlatformStatus>> FetchAndMapPlatformStatusesAsync();

    }
}
