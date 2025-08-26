using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Payment;

public interface IPaymentService
{
    Task<ResponseServer> HandlePaymentAsync(
        string userId,
        Guid orderHeaderId,
        string cardNumber);
}