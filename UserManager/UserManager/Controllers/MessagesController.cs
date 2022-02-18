using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using UserManager.Services.IServices;
using UserManager.Services.Models;

namespace UserManager.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessagesService _messagesService;
        private readonly IUsersService _usersService;

        public MessagesController(IMessagesService messagesService, IUsersService usersService)
        {
            _messagesService = messagesService;
            _usersService = usersService;

        }

        [HttpGet]
        [Authorize]
        public IActionResult Send()
        {
            CompositeModel compositeModel = new CompositeModel();

            var models = _usersService.GetAllUsers();
            compositeModel.users = models;

            return View(compositeModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Send(CompositeModel model)
        {
            if (ModelState.IsValid)
            {
                await _messagesService.CreateMessageAsync(model.messageModel);
                var senderId = _usersService.GetUserByEmail(model.messageModel.SenderEmail).UserId;

                return RedirectToAction("GetSent", new { senderId });
            }
            else
            {
                model.users = _usersService.GetAllUsers();
                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetSent(int senderId, int currentPage)
        {
            var messages = _messagesService.GetSent(senderId, currentPage);

            return View("Sent", messages);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetInbox(int recipientId, int currentPage)
        {
            var messages = _messagesService.GetInbox(recipientId, currentPage);

            return View("Inbox", messages);
        }

        [HttpPost]
        [Authorize]
        public void UpdateMessageState(int messageId)
        {
            _messagesService.UpdateMessageState(messageId);
        }



    }
}
