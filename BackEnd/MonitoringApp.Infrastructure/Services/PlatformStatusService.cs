using MonitoringApp.Application.Interfaces;
using MonitoringApp.Domain.Entities;
using System.Text.Json;

namespace MonitoringApp.Infrastructure.Services
{
    public class PlatformStatusService : IPlatformStatusService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILoggerService<PlatformStatusService> _logger;

        public PlatformStatusService(IHttpClientService httpClientService, ILoggerService<PlatformStatusService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }

        public async Task<List<PlatformStatus>> FetchAndMapPlatformStatusesAsync()
        {
            _logger.LogInformation("Fetching platform statuses from external APIs.");

            var platforms = new List<(string Name, string Url)>
            {
                ("Mercado Pago", "https://mercadopago.bistrosoft.com/api/check"),
                ("Modo", "https://modo.bistrosoft.com/api/v1/check"),
                ("Multidelivery", "https://multidelivery.bistrosoft.com/api/check"),
                ("Clip", "https://mx-clip.bistrosoft.com/api/v1.0/check")
            };

            var results = new List<PlatformStatus>();

            foreach (var platform in platforms)
            {
                try
                {
                    _logger.LogInformation($"Fetching status for platform {platform.Name} from {platform.Url}.");
                    var response = await _httpClientService.GetStringAsync(platform.Url);

                    var responseData = JsonSerializer.Deserialize<ApiResponse>(response);

                    var platformStatus = new PlatformStatus
                    {
                        PlatformName = platform.Name,
                        Version = responseData?.version ?? "N/A",
                        Status = responseData?.responseCode switch
                        {
                            0 => "OK",          
                            -1 => "ERROR",      
                            _ => "NOT RECOGNIZED"
                        }
                    };

                    results.Add(platformStatus);

                    _logger.LogInformation($"Successfully fetched status for platform {platform.Name}.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to fetch status for platform {platform.Name}.", ex);

                    results.Add(new PlatformStatus
                    {
                        PlatformName = platform.Name,
                        Version = "N/A",
                        Status = "ERROR",
                    });
                }
            }

            _logger.LogInformation("Finished fetching all platform statuses.");
            return results;
        }

        // Clase interna para modelar las respuestas de las APIs externas
        private class ApiResponse
        {
            public string version { get; set; }
            public int responseCode { get; set; }
        }
    }


}
