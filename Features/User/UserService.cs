using BackendTest.Features.Shared;
using BackendTest.Features.User.Resources;

namespace BackendTest.Features.User;

public interface IUserService
{
    TokenResource Authenticate(LoginResource model);
    IEnumerable<UserEntity> GetAll();
    UserEntity GetById(int id);
}

public class UserService : IUserService
{
    private IUnitOfWork UnitOfWork { get; set; }

    public UserService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    
    public TokenResource Authenticate(LoginResource model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public UserEntity GetById(int id)
    {
        throw new NotImplementedException();
    }
}
