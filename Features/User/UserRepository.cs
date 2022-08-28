using BackendTest.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.User;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<UserEntity> GetByEmailAsync(string email);
    Task<UserEntity> GetByIdWithCartAsync(int id);
}

public class UserRepository : Repository<UserEntity>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {

    }

    public async Task<UserEntity> GetByEmailAsync(string email)
        => await Context.Set<UserEntity>().FirstOrDefaultAsync(x => x.Email == email);

    public async Task<UserEntity> GetByIdWithCartAsync(int id)
        => await Context.Set<UserEntity>().Include(u => u.Cart).FirstOrDefaultAsync(u => u.Id == id);
    
}
