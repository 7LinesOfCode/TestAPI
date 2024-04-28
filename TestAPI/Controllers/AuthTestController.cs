using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthTestController : ControllerBase
{
    [HttpGet]
    [Route("AuthOnlyAction")]
    [Authorize]
    public async Task<IActionResult> AuthOnlyAction()
    {
        return Ok("Auth only action allowed");
    }
    
    [HttpGet]
    [Route("AuthTest")]
    public async Task<IActionResult> AuthTest()
    {
        if (User.Identity.IsAuthenticated)
        {
            return Ok("Authorized");
        }
        else
        {
            return Ok("Unauthorized");
        }
    }
}