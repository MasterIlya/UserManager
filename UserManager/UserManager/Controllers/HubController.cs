using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Services.Hubs;
using UserManager.Services.IServices;
using UserManager.Services.Models;

namespace UserManager.Controllers
{
    public class HubController : Controller
    {
        private readonly IHubConnectionService _hubConnectionService;    
        public HubController(IHubContext<NotificationHub> hubContext, IHubConnectionService hubConnectionService)
        {
            _hubConnectionService = hubConnectionService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult RegistrateHubConnectionId(HubConnectionModel model)
        {
            _hubConnectionService.AddToCache(model);

            return Ok();
        }
    }
}
