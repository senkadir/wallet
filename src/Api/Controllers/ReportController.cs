using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{periodCode}")]
        public async Task<IActionResult> GetByPeriod([FromRoute] string periodCode)
        {
            return Ok();
        }


    }
}
