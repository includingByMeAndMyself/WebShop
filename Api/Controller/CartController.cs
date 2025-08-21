using System.Net;
using Api.Data;
using Api.Model;
using Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller;

public class CartController : StoreController
{
    private readonly CartService _cartService;

    public CartController(AppDbContext dbContext, CartService cartService) : base(dbContext)
    {
        _cartService = cartService;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseServer>> AppendOrUpdateItemInCart(
        string userId,
        Guid productId,
        int updateQuantity)
    {
        var product = await dbContext
            .Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null)
        {
            return BadRequest(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = { "Товар не найден" }
            });
        }

        var cart = await dbContext
            .Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart is null
            && updateQuantity > 0)
        {
            await _cartService.CreateNewCartAsync(userId, productId, updateQuantity);
        }
        else if(cart != null)
        {
            await _cartService.UpdateExistingCartAsync(cart, productId, updateQuantity);
        }

        return Ok(new ResponseServer()
        {
            StatusCode = HttpStatusCode.OK
        });
    }

    [HttpGet]
    public async Task<ActionResult<ResponseServer>> GetCart(string userId)
    {
        try
        {
            var cart = await _cartService.GetCartAsync(userId);

            return Ok(new ResponseServer()
            {
                StatusCode = HttpStatusCode.OK,
                Result = cart
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { ex.Message }
            });
        }
    }
}