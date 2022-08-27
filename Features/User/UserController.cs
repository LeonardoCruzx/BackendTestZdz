using AutoMapper;
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

    private IMapper Mapper { get; set; }

    private IUserService UserService { get; set; }

    public UserController(
        IValidator<SignUpResource> signUpResourceValidator, 
        IValidator<LoginResource> loginResourceValidator,
        IMapper mapper,
        IUserService userService
    )
    {
        SignUpResourceValidator = signUpResourceValidator;
        LoginResourceValidator = loginResourceValidator;
        Mapper = mapper;
        UserService = userService;
    }
    
    [AllowAnonymous]
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpResource signUpResource)
    {
        var validationResult = SignUpResourceValidator.Validate(signUpResource);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var userToSave = Mapper.Map<UserEntity>(signUpResource);

        var token = await UserService.SignUp(userToSave);

        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login(LoginResource loginResource)
    {
        var validationResult = LoginResourceValidator.Validate(loginResource);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var token = UserService.Authenticate(loginResource);

        if (token is null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(token);
    }
}
