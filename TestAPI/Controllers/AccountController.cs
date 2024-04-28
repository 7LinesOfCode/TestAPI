using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("SignIn")]
    public async Task<IActionResult> SiginIn()
    {
        var claims = new List<Claim>
            {
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(10),
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity), 
                authProperties);
        
        return Ok("Authentication success");
    }
   
    [HttpPost]
    [Route("SignOut")]
    public async Task SignOut()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
    }
}