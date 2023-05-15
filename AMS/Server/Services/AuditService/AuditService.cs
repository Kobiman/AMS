
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services.AuditService
{
    public class AuditService : IAuditService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuditService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Audit>> GetAuditRecords(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);
            //return await _dbContext.Audits.Where(x => x.TimeAccessed<endDate && x.TimeAccessed > startDate).ToListAsync();
            var result = await (from a in _dbContext.Audits 
                         where
                         a.TimeAccessed >= startDate &&
                         a.TimeAccessed < endDate
                         select new Audit 
                         { 
                             AuditID=a.AuditID,
                             UserName=a.UserName,
                             ControllerName=a.ControllerName,
                             ActionName=a.ActionName,
                             TimeAccessed=a.TimeAccessed,
                             PageAccessed=a.PageAccessed
                         }).ToListAsync();
            return result;
        }

        public async Task InsertAuditRecord(Audit audit)
        {
            await _dbContext.Audits.AddAsync(audit);
            await _dbContext.SaveChangesAsync();
        }
    }
}
