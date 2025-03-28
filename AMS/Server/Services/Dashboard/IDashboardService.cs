namespace AMS.Server.Services.Dashboard
{
    public interface IDashboardService
    {
        DisplayTotals GetTotals(string? period="");

        Task<IEnumerable<DisplayTotals>> GetValuesGroupedByLocation(string? period = "");
    }
}
