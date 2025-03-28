

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;
        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisplayTotals>>  GetValuesGroupedByLocation(string? period = "")
        {
            DateRange.GetDates(period, out DateTime startDate, out DateTime endDate);
            var listA = await (from w in _context.Wins.Where(_=>_.EntryDate >= startDate && _.EntryDate <= endDate)
                              join l in _context.Locations on w.LocationId equals l.Id into agac
                              from pw in agac.DefaultIfEmpty()

                              select new DisplayTotals
                              {
                                  UnpaidWins = w.WinAmount,
                                  Location = pw == null ? "Random" : pw.LocationName
                              }).ToListAsync();

            
            var listB = await (from p in _context.Payouts.Where(_=>_.EntryDate >= startDate && _.EntryDate <= endDate)
            join l in _context.Locations on p.LocationId equals l.Id into agac
            from pl in agac.DefaultIfEmpty()

            select new DisplayTotals
            {
                PayIn =  (p.Type == "Payin") ? p.Amount: 0,
                PayOut = (p.Type == "Payout") ? Math.Abs(p.Amount) : 0,
                UnpaidWins = (p.Type == "Payout") ? (p.Amount) : 0,
                Location = pl == null? "": pl.LocationName
            }).ToListAsync();

            listA.AddRange(listB);

            var groupedListP = listA
                .GroupBy(l => l.Location)
                .Select(nl => new DisplayTotals
                {
                    PayIn = nl.Sum(x => x.PayIn),
                    PayOut = nl.Sum(x => x.PayOut),
                    UnpaidWins= (nl.Sum(x => x.UnpaidWins))<0?0: (nl.Sum(x => x.UnpaidWins)),
                    Location = nl.First().Location
                });
            return groupedListP;
        }

        public DisplayTotals GetTotals(string? period = "")
        {
            DateRange.GetDates(period, out DateTime startDate, out DateTime endDate);
            return new DisplayTotals
            {
                PayIn = _context.Payouts.Where(c => c.Type == "Payin" && (c.EntryDate >= startDate && c.EntryDate <= endDate))                                        
                                        .Sum(x => x.Amount),
                PayOut = -(_context.Payouts.Where(c => c.Type == "Payout" && (c.EntryDate >= startDate && c.EntryDate <= endDate))
                                           .Sum(x => x.Amount)),

                UnpaidWins = ((_context.Wins.Where(d=>d.EntryDate>= startDate && d.EntryDate<=endDate).Sum(x => x.WinAmount))
                -(Math.Abs(_context.Payouts.Where(c => c.Type == "Payout" && (c.EntryDate >= startDate && c.EntryDate <= endDate)).Sum(x => x.Amount))))<0?0:
                ((_context.Wins.Where(d => d.EntryDate >= startDate && d.EntryDate <= endDate).Sum(x => x.WinAmount))
                - (Math.Abs(_context.Payouts.Where(c => c.Type == "Payout" && (c.EntryDate >= startDate && c.EntryDate <= endDate)).Sum(x => x.Amount)))),
                
            };
        }
    }
}
