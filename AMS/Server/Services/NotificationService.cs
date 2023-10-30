using Newtonsoft.Json;
using System.Text;

namespace AMS.Server.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendSMS(string message, string contact)
        {
            var req = new { sender = "AMS", message, recipients = new string[] { contact } };
            var json = JsonConvert.SerializeObject(req);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var endPoint = $"https://sms.arkesel.com/api/v2/sms/send";
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("api-key", "OjZqeWo4QlFOSEc5V2xwb2g");
            var response = await client.PostAsync(endPoint, data).ConfigureAwait(false);
        }

        public async Task SendBulkSMS(string message, string[] contacts)
        {
            var req = new { sender = "AMS", message, recipients = contacts };
            var json = JsonConvert.SerializeObject(req);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var endPoint = $"https://sms.arkesel.com/api/v2/sms/send";
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("api-key", "OjZqeWo4QlFOSEc5V2xwb2g");
            var response = await client.PostAsync(endPoint, data).ConfigureAwait(false);
        }
    }
}
