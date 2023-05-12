namespace AMS.Shared
{
    public class Audit
    {
        public Audit()
        {

        }
        public int AuditID { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? IPAddress { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? PageAccessed { get; set; }
        public DateTime TimeAccessed { get; set; }
    }
}
