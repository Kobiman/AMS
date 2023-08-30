using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Location>> AddLocation(Location location)
        {
            var result = new Result<Location>();
            var locInDb = await _dbContext.Locations.FirstOrDefaultAsync(x => x.LocationName.ToUpper() == location.LocationName.ToUpper());
            if(locInDb != null)
            {
                result = new Result<Location>() { IsSucessful = false, Value = null, Message = "Location Already Exists" };
                return result;
            }
            else
            {
                await _dbContext.Locations.AddAsync(location);
                await _dbContext.SaveChangesAsync();
                result = new Result<Location>() { IsSucessful=true,Value = location, Message="Record Saved Successfully"};
                return result;
            }
           
        }

        public async Task<Location> GetLocationById(int locationId)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == locationId);
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _dbContext.Locations.ToListAsync();
        }
    }
}
