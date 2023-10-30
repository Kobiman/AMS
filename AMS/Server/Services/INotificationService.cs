namespace AMS.Server.Services
{
    public interface INotificationService
    {
        Task SendSMS(string message, string contact);
        Task SendBulkSMS(string message, string[] contacts);
    }
}
