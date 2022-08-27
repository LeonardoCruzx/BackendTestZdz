using BackendTest.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.User;

public class UserRepository : Repository<UserEntity>
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}
