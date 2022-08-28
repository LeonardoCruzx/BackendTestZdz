using BackendTest.Features.Cart;
using BackendTest.Features.Item;
using BackendTest.Features.User;

namespace BackendTest.Features.Shared;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    ICartRepository CartRepository { get; }
    IItemRepository ItemRepository { get; }
    Task CommitAsync();
}
public class UnitOfWork : IUnitOfWork
{
    private BackendTestContext Context { get; set; }

    private UserRepository userRepository;
    private CartRepository cartRepository;
    private ItemRepository itemRepository;

    public UnitOfWork(BackendTestContext context)
    {
        Context = context;
    }

    public IUserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(Context));
    public ICartRepository CartRepository => cartRepository ?? (cartRepository = new CartRepository(Context));
    public IItemRepository ItemRepository => itemRepository ?? (itemRepository = new ItemRepository(Context));

    public async Task CommitAsync()
        => await Context.SaveChangesAsync();

    public void Dispose()
        => Context.Dispose();
}
