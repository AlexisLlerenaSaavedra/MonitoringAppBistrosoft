using MediatR;
using MonitoringApp.Application.DTOs;


namespace MonitoringApp.Application.Queries.GetPlatformStatuses
{
    public class GetPlatformStatusesQuery : IRequest<IEnumerable<PlatformStatusDto>>
    {
    }
}
