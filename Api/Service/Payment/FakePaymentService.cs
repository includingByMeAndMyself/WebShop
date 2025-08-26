using System.Net;
using Api.Data;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Payment;

public class FakePaymentService : IPaymentService
{
    private readonly AppDbContext _dbContext;

    public FakePaymentService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ResponseServer> HandlePaymentAsync(string userId, Guid orderHeaderId, string cardNumber)
    {
        var shoppingCart = await _dbContext
            .Carts
            .Include(x => x.CartItems)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (shoppingCart is null
            || shoppingCart.CartItems is null
            || shoppingCart.CartItems.Count == 0)
        {
            return new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Корзина пуста или не найдена" }
            };
        }

        shoppingCart.TotalAmount = shoppingCart
            .CartItems
            .Sum(x => x.Quantity * x.Product.Price);

        PaymentResponse paymentResponse;
        if (!string.IsNullOrEmpty(cardNumber))
        {
            paymentResponse = new PaymentResponse()
            {
                IsSuccess = true,
                IntentId = "fake_intend_id",
                Secret = "fake_secret"
            };
        }
        else
        {
            paymentResponse = new PaymentResponse()
            {
                IsSuccess = false,
                IntentId = string.Empty,
                Secret = string.Empty,
                ErrorMessage = "Недействительная карта"
            };
        }

        return new ResponseServer()
        {
            IsSuccess = paymentResponse.IsSuccess,
            Result = paymentResponse,
            ErrorMessages = { paymentResponse.ErrorMessage },
            StatusCode = paymentResponse.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest
        };
    }
}