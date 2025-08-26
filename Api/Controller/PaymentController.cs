using System.Net;
using Api.Data;
using Api.Model;
using Api.Service.Payment;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class PaymentController : StoreController
{
    private readonly FakePaymentService _paymentService;

    public PaymentController(
        AppDbContext dbContext,
        FakePaymentService paymentService) : base(dbContext)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseServer>> MakePayment(
        [FromBody] string userId, Guid orderHeaderId, string cardNumber)
    {
        try
        {
            var response = await _paymentService.HandlePaymentAsync(userId, orderHeaderId, cardNumber);
            return StatusCode((int)response.StatusCode, response);
        }
        catch (Exception e)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError,
                new ResponseServer()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessages = { e.Message }
                });
        }
    }
}