using BackendTest.Features.Cart.Resources;
using BackendTest.Features.Cart.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Features.Cart;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private ICartService CartService { get; set; }

    private AddItemResourceValidator AddItemResourceValidator { get; set; }

    public CartController(ICartService cartService, AddItemResourceValidator addItemResourceValidator)
    {
        CartService = cartService;
        AddItemResourceValidator = addItemResourceValidator;
    }

    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Items(int id)
    {
        return Ok(await CartService.GetItemsByIdAsync(id));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddItem(AddItemResource addItemResource)
    {
        var validationResult = AddItemResourceValidator.Validate(addItemResource);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await CartService.AddItemCartAsync(addItemResource);

        return Ok();
    }
}
