using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AMS.Server.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendSMS(string message, string contact)
        {
            var req = new { from = "AMSEROILAPP", content = message, to = contact };
            var json = JsonConvert.SerializeObject(req);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var endPoint = $"https://smsc.hubtel.com/v1/messages/send";
            using HttpClient client = new();
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes("qxbqqmkn:vngouhbn"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64String);
            var response = await client.PostAsync(endPoint, data).ConfigureAwait(false);
        }

        public async Task SendBulkSMS(string message, string[] contacts)
        {
            foreach (var contact in contacts)
            {
                var req = new { from = "AMSEROILAPP", content = message, to = contact };
                var json = JsonConvert.SerializeObject(req);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var endPoint = $"https://smsc.hubtel.com/v1/messages/send";
                using HttpClient client = new();
                var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes("qxbqqmkn:vngouhbn"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64String);
                var response = await client.PostAsync(endPoint, data).ConfigureAwait(false);
            }
        }
    }
}
