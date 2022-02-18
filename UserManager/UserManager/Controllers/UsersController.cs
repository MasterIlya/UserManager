using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManager.Commons.Enums;
using UserManager.Services.IServices;
using UserManager.Services.Models;
using Microsoft.AspNetCore.SignalR;

namespace UserManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult Registration(RegistrationUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_usersService.GetUserByEmail(model.Email) == null || _usersService.GetUserByEmail(model.Email).Delisted == true)
                {
                    _usersService.CreateUser(model);

                    return View("SuccessRegistration");
                }
                else
                {
                    ModelState.AddModelError("", "Such user is blocked or already exists!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Authentication()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = _usersService.GetUserByEmail(userModel.Email);

                if (user != null && user.State != StateTypes.BLOCKED && user.Password == userModel.Password)
                {

                    await Authenticate(user.UserId, user.Email);
                    _usersService.UpdateLoginDate(userModel);
                    return RedirectToAction("GetUsers");

                }
                ModelState.AddModelError("", "Incorrect login and/or password, or you are blocked");
            }

            return View("Authentication", userModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsers(int currentPage)
        {
            var users = _usersService.GetUsers(currentPage);


            return View("Users", users);
        }


        [HttpPost]
        [Authorize]
        public IActionResult ChangeState(int[] ids, string btn)
        {
            if(btn == "block")
            {
                _usersService.BlockUsers(ids);
            }
            else if(btn == "unblock")
            {
                _usersService.UnblockUsers(ids);
            }
            else if(btn == "delete")
            {
                _usersService.DeleteUsers(ids);
            }

            return RedirectToAction("GetUsers");

        }

        private async Task Authenticate(int userId, string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Authentication");
        }

    }
}
