using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IAgentService _agentService;

        public NotificationController(INotificationService notificationService,IAgentService agentService)
        {
            _notificationService = notificationService;
            _agentService = agentService;
        }

        [HttpPost]
        public async Task<ActionResult> SendBulkSMS([FromBody] NotificationRequest notification)
        {
            var allagents = await _agentService.GetAgents();
            string[] phonenos = new string[allagents.Count()];
            foreach(var agent in allagents)
            {
                phonenos.Append(agent.Phone);
            }
            try
            {
                //await _notificationService.SendBulkSMS(msg, phonenos);
                await _notificationService.SendSMS("Kobi Man", "0278312378");
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Sending Message");
            }
        }

        public record NotificationRequest(string  message);
    }
}
