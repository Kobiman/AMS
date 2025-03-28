using AMS.Server.Services.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboard;

        public DashboardController(IDashboardService dashboard)
        {
            _dashboard = dashboard;
        }

        [HttpGet("totals/{period}")]
        public IActionResult GetTotals(string? period = "")
        {
            return Ok(_dashboard.GetTotals(period));
        }

        [HttpGet("ChartValues/{period}")]
        public async Task<IActionResult> GetValuesGroupedByLocation(string? period = "") 
        {
            return Ok(await _dashboard.GetValuesGroupedByLocation( period));
        }

    }
}
