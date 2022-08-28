using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackendTest.Features.Cart;
using BackendTest.Features.Shared;
using BackendTest.Features.User.Resources;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BackendTest.Features.User;

public interface IUserService
{
    Task<TokenResource> SignUp(UserEntity user);
    Task<TokenResource> Authenticate(LoginResource model);
    Task<UserEntity> GetById(int id);
    Task<UserEntity> GetByIdWithCart(int id);
}

public class UserService : IUserService
{
    private AppSettings AppSettings { get; set; }
    private IUnitOfWork UnitOfWork { get; set; }

    public UserService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
    {
        UnitOfWork = unitOfWork;
        AppSettings = appSettings.Value;
    }

    public async Task<TokenResource> SignUp(UserEntity user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var cart = new CartEntity(user);

        user.Cart = cart;

        await UnitOfWork.UserRepository.AddAsync(user);

        await UnitOfWork.CartRepository.AddAsync(cart);

        await UnitOfWork.CommitAsync();

        return new TokenResource(GenerateJwtToken(user));
    }

    public async Task<TokenResource> Authenticate(LoginResource loginResource)
    {
        var user = await UnitOfWork.UserRepository.GetByEmailAsync(loginResource.Email);

        if (user is not null && BCrypt.Net.BCrypt.Verify(loginResource.Password, user.Password))
            return new TokenResource(GenerateJwtToken(user));

        return null;
    }

    public async Task<UserEntity> GetById(int id)
        => await UnitOfWork.UserRepository.GetByIdAsync(id);

    public async Task<UserEntity> GetByIdWithCart(int id)
        => await UnitOfWork.UserRepository.GetByIdWithCartAsync(id);

    private string GenerateJwtToken(UserEntity user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
}
