namespace AMS.Server.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Result<Location>> AddLocation(Location location);
        Task<Location> GetLocationById(int locationId);
    }
}
