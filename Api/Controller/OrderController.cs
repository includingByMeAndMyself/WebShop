using System.Net;
using Api.Data;
using Api.Model;
using Api.ModelDto;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class OrderController : StoreController
{
    private readonly OrderService _orderService;

    public OrderController(
        AppDbContext dbContext,
        OrderService orderService)
        : base(dbContext)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseServer>> CreateOrder(
        [FromBody] OrderHeaderCreateDto orderHeaderCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Неверное состояние модели заказа" }
            });
        }

        try
        {
            var order = await _orderService.CreateOrderAsync(orderHeaderCreateDto);
            //order.OrderDetails = null;

            return Ok(new ResponseServer()
            {
                StatusCode = HttpStatusCode.Created,
                Result = order
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { e.Message }
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<ResponseServer>> GetOrderById(Guid id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);

        if (order is null)
        {
            return NotFound(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = { "Заказ не найден" }
            });
        }

        return Ok(new ResponseServer()
        {
            StatusCode = HttpStatusCode.OK,
            Result = order
        });
    }

    [HttpGet]
    public async Task<ActionResult<ResponseServer>> GetOrderByUserId(string id)
    {
        try
        {
            var orderHeader = await _orderService.GetOrderByUserIdAsync(id);
            return Ok(new ResponseServer()
            {
                StatusCode = HttpStatusCode.OK,
                Result = orderHeader
            });
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

    [HttpPut("{id}")]
    public async Task<ActionResult<ResponseServer>> UpdateOrderHeader(Guid id,
        [FromBody] OrderHeaderUpdateDto orderHeaderUpdateDto)
    {
        try
        {
            var isSuccess = await _orderService.UpdateOrderHeaderAsync(id, orderHeaderUpdateDto);
            Object result = isSuccess
                ? Ok(new ResponseServer()
                {
                    StatusCode = HttpStatusCode.OK
                })
                : BadRequest(new ResponseServer()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Во время обновления возникла ошибка" }
                });

            return (ActionResult<ResponseServer>)result;
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