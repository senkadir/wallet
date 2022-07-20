using Core.Services;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("periods")]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodService _periodService;

        public PeriodController(IPeriodService periodService)
        {
            _periodService = periodService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePeriodCommand command)
        {
            await _periodService.CreateAsync(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _periodService.GetAsync());
        }
    }
}
