using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _locationService.GetLocations();
        }

        [HttpGet("{locId}")]
        public async Task<Location> GetLocationById(int locId)
        {
            return await _locationService.GetLocationById(locId);
        }

        [HttpPost]
        public async Task<Result<Location>> AddLocation(Location location)
        {
            return await _locationService.AddLocation(location);
        }
    }
}
