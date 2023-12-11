using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [AllowAnonymous]

        public async Task<ActionResult<Location>> GetLocationById(int locId)
        {
            try
            {
                return Ok( await _locationService.GetLocationById(locId));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
            
        }

        [HttpPost]
        public async Task<Result<Location>> AddLocation(Location location)
        {
            return await _locationService.AddLocation(location);
        }
    }
}
