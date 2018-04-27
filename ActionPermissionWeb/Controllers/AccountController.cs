using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ActionPermissionWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            var property = new AuthenticationProperties()
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(2),
                IsPersistent = true,
            };
            ClaimsIdentity identity = new ClaimsIdentity("actionPermission");
            identity.AddClaim(new Claim(ClaimTypes.Email, "234123@qq.com"));
            identity.AddClaim(new Claim(ClaimTypes.Name, "Tim"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            ClaimsPrincipal user = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(user, property);
            return Content("Login Success");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Content("Logout Success");
        }
    }
}