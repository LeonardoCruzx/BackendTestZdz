using BackendTest.Features.User.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Features.User;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("signup")]
    public IActionResult SignUp(SignUpResource signUpResource)
    {
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginResource loginResource)
    {
        return Ok();
    }
}
