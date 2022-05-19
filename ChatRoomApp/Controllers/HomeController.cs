using ChatRoomApp.Core.Services.ChatRoom;
using ChatRoomApp.Data;
using ChatRoomApp.Helpers;
using ChatRoomApp.Infrastructure.Bot;
using ChatRoomApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ChatRoomUser> _userManager;
        private readonly ChatService _chatService;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<ChatRoomUser> userManager,
            ChatService chatService)
        {
            _logger = logger;
            _userManager = userManager;
            _chatService = chatService;
        }

        public async Task<IActionResult> Index()
        {
            var loggedUser = await _userManager.GetUserAsync(User);
            ViewBag.DisplayName = loggedUser.DisplayName;
            ViewBag.UserId = loggedUser.Id;

            var messages = await _chatService.GetMessages(50);

            return View(messages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ChatMessage model)
        {
            if (ModelState.IsValid)
            {
                model.Message = model.Message.Trim();

                model.UserName = User.Identity.Name;
                var user = await _userManager.GetUserAsync(User);
                model.UserId = user.Id;

                await _chatService.SendMessage(model);

                return Ok();
            }

            return Error();
        }
    }
}
