using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ApplicationDbContext _dbContext;

        public NotificationController(INotificationService notificationService, ApplicationDbContext dbContext)
        {
            _notificationService = notificationService;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> SendBulkSMS([FromBody] string msg)
        {
            var allagents =  await _dbContext.Agents.ToListAsync();
            string[] phonenos = (from a in allagents
                                 where a.Phone != ""
                                 && a.Phone != null
                                 select a.Phone).ToArray();
            try
            {
                await _notificationService.SendBulkSMS(msg, phonenos);
                //await _notificationService.SendSMS("Kobi Man", "0278312378");
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
