
namespace AMS.Server.Services.AuditService
{
    public interface IAuditService
    {
        Task InsertAuditRecord(Audit audit);
        Task <IEnumerable<Audit>> GetAuditRecords(DateRange period);
    }
}
