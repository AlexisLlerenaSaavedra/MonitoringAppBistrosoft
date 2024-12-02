using MediatR;
using Microsoft.AspNetCore.Mvc;
using MonitoringApp.Application.DTOs;
using MonitoringApp.Application.Interfaces;
using MonitoringApp.Application.Queries.GetPlatformStatuses;

namespace MonitoringApp.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlatformStatusController : ControllerBase
	{
		private readonly IMediator _mediator;
        private readonly ILoggerService<PlatformStatusController> _logger;



        public PlatformStatusController(IMediator mediator, ILoggerService<PlatformStatusController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet("statuses")]
        public async Task<IActionResult> GetStatuses()
        {
            _logger.LogInformation("Received request to fetch platform statuses.");

            try
            {
                var statuses = await _mediator.Send(new GetPlatformStatusesQuery());
                _logger.LogInformation("Successfully retrieved platform statuses.");
                return Ok(statuses);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while fetching platform statuses.", ex);
                return StatusCode(500, "An error occurred while processing your request.");
            }

            
        }
    }
}
