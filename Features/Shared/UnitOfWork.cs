using BackendTest.Features.User;

namespace BackendTest.Features.Shared;

public interface IUnitOfWork : IDisposable
{
    
}
public class UnitOfWork : IUnitOfWork
{
    private BackendTestContext Context { get; set; }

    private UserRepository userRepository;

    public UnitOfWork(BackendTestContext context)
    {
        Context = context;
    }

    public UserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(Context));

    public async Task CommitAsync()
        => await Context.SaveChangesAsync();

    public void Dispose()
        => Context.Dispose();
}
