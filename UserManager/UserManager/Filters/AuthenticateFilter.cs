using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;
using UserManager.Commons.Enums;
using UserManager.Services.IServices;

namespace UserManager.Filters
{
    public class AuthenticateFilter : IResourceFilter
    {
        private readonly IUsersService _usersService;
        public AuthenticateFilter(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var userIdClaims = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaims != null)
            {
                var user = _usersService.GetUserById(int.Parse(userIdClaims.Value));

                if (user.Delisted || user.State == StateTypes.BLOCKED)
                {

                    foreach (var cookie in context.HttpContext.Request.Cookies)
                    {
                        context.HttpContext.Response.Cookies.Delete(cookie.Key);
                    }
                    context.Result = new RedirectResult("~/Users/Authentication");
                }
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        { 

        }


    }
}
