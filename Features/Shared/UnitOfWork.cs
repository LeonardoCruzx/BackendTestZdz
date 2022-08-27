using BackendTest.Features.User;

namespace BackendTest.Features.Shared;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    Task CommitAsync();
}
public class UnitOfWork : IUnitOfWork
{
    private BackendTestContext Context { get; set; }

    private UserRepository userRepository;

    public UnitOfWork(BackendTestContext context)
    {
        Context = context;
    }

    public IUserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(Context));

    public async Task CommitAsync()
        => await Context.SaveChangesAsync();

    public void Dispose()
        => Context.Dispose();
}
