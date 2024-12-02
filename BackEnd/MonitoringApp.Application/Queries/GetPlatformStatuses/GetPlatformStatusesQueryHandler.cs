using AutoMapper;
using MediatR;
using MonitoringApp.Application.DTOs;
using MonitoringApp.Application.Interfaces;

namespace MonitoringApp.Application.Queries.GetPlatformStatuses
{
    public class GetPlatformStatusesQueryHandler : IRequestHandler<GetPlatformStatusesQuery, IEnumerable<PlatformStatusDto>>
    {
        private readonly IPlatformStatusRepository _repository;
        private readonly IPlatformStatusService _platformStatusService;
        private readonly IMapper _mapper;
        private readonly ILoggerService<GetPlatformStatusesQueryHandler> _logger;

        public GetPlatformStatusesQueryHandler(
            IPlatformStatusRepository repository,
            IPlatformStatusService platformStatusService,
            IMapper mapper,
            ILoggerService<GetPlatformStatusesQueryHandler> logger)
        {
            _repository = repository;
            _platformStatusService = platformStatusService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PlatformStatusDto>> Handle(GetPlatformStatusesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching platform statuses via service.");

            // Llamar al servicio para obtener los datos de las APIs externas
            var platformStatuses = await _platformStatusService.FetchAndMapPlatformStatusesAsync();

            // Guardar los datos en la base de datos
            await _repository.AddPlatformStatusesAsync(platformStatuses);

            // Recuperar los datos guardados para retornar
            var savedStatuses = await _repository.GetAllPlatformStatusesAsync();

            // Imprimir los datos en consola 
            Console.WriteLine("=== Datos guardados en la base de datos en memoria ===");
            foreach (var status in savedStatuses)
            {
                Console.WriteLine($"Plataforma: {status.PlatformName}, Versión: {status.Version}, Estado: {status.Status}");
            }
            Console.WriteLine("=====================================================");

            // Mapear a DTOs usando AutoMapper
            var platformStatusDtos = _mapper.Map<IEnumerable<PlatformStatusDto>>(savedStatuses);

            _logger.LogInformation("Successfully handled GetPlatformStatusesQuery.");
            return platformStatusDtos;
        }
    }

}
