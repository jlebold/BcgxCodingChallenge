using BcgxCodingChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace BcgxCodingChallenge.Controllers;
[ApiController]
public class ShoppingController : ControllerBase
{
    private readonly ILogger<ShoppingController> _logger;
    private readonly IShoppingService _checkoutService;

    public ShoppingController(ILogger<ShoppingController> logger, IShoppingService checkoutService)
    {
        _logger = logger;
        _checkoutService = checkoutService;
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout(IEnumerable<string> watchIds)
    {
        var result = await _checkoutService.CalculateCost(watchIds);

        return result != null ? 
            Ok(result) :
            BadRequest();
    }
}
