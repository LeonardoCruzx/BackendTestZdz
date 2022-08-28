using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Features.Cart;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private ICartService CartService { get; set; }

    public CartController(ICartService cartService)
    {
        CartService = cartService;
    }

    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Items(int id)
    {
        return Ok(await CartService.GetItemsByIdAsync(id));
    }
}
