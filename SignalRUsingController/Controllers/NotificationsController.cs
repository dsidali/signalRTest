using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRUsingController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationsController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationModel notification)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", notification.User,notification.Message);
            return Ok();
        }

        public class NotificationModel
        {
            public string Message { get; set; }
            public string User { get; set; }
        }
    }
}
