using BackendTest.Features.User.Resources;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Features.User;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private IValidator<SignUpResource> SignUpResourceValidator { get; set; }
    private IValidator<LoginResource> LoginResourceValidator { get; set; }

    public UserController(
        IValidator<SignUpResource> signUpResourceValidator, 
        IValidator<LoginResource> loginResourceValidator
    )
    {
        SignUpResourceValidator = signUpResourceValidator;
        LoginResourceValidator = loginResourceValidator;
    }
    
    [AllowAnonymous]
    [HttpPost("signup")]
    public IActionResult SignUp(SignUpResource signUpResource)
    {
        var validationResult = SignUpResourceValidator.Validate(signUpResource);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginResource loginResource)
    {
        var validationResult = LoginResourceValidator.Validate(loginResource);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        return Ok();
    }
}
