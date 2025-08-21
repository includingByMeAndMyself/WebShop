using Api.Data;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class CartService
{
    private readonly AppDbContext _dbContext;

    public CartService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateNewCartAsync(string userId, Guid productId, int quantity)
    {
        var cart = new Cart
        {
            UserId = userId
        };

        await _dbContext.Carts.AddAsync(cart);
        await _dbContext.SaveChangesAsync();

        var cartItem = new CartItem()
        {
            ProductId = productId,
            Quantity = quantity,
            CartId = cart.Id
        };

        await _dbContext.CartItems.AddAsync(cartItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateExistingCartAsync(
        Cart cart,
        Guid productId,
        int newQuantity)
    {
        var cartItemsInCart = cart
            .CartItems
            .FirstOrDefault(e => e.ProductId == productId);

        if (cartItemsInCart is null && newQuantity > 0)
        {
            var cartItem = new CartItem()
            {
                ProductId = productId,
                Quantity = newQuantity,
                CartId = cart.Id
            };

            await _dbContext.CartItems.AddAsync(cartItem);
        }
        else if(cartItemsInCart != null)
        {
            var updateQuantity = cartItemsInCart.Quantity + newQuantity;

            if (newQuantity == 0 || updateQuantity <= 0)
            {
                _dbContext.CartItems.Remove(cartItemsInCart);

                if (cart.CartItems.Count == 1)
                {
                    _dbContext.Carts.Remove(cart);
                }
            }
            else
            {
                cartItemsInCart.Quantity = newQuantity;
            }
        }
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Cart> GetCartAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return new Cart();
        }

        var cart = await _dbContext
            .Carts
            .Include(u => u.CartItems)
            .ThenInclude(u => u.Product)
            .FirstOrDefaultAsync(u => u.UserId == userId);

        if (cart != null && cart.CartItems != null)
        {
            cart.TotalAmount = cart
                .CartItems
                .Sum(u => u.Quantity * u.Product.Price);
        }

        return cart ?? new Cart();
    }
}