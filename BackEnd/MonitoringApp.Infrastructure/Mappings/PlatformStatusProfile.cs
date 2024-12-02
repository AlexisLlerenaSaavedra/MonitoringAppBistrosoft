using AutoMapper;
using MonitoringApp.Application.DTOs;
using MonitoringApp.Domain.Entities;

namespace MonitoringApp.Infrastructure.Mappings
{
	public class PlatformStatusProfile : Profile
	{
		public PlatformStatusProfile()
		{
			CreateMap<PlatformStatus, PlatformStatusDto>().ReverseMap();
		}
	}
}
