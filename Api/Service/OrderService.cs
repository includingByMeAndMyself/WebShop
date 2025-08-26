using Api.Common;
using Api.Data;
using Api.Model;
using Api.ModelDto;
using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class OrderService
{
    private readonly AppDbContext _dbContext;

    public OrderService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OrderHeader> CreateOrderAsync(
        OrderHeaderCreateDto orderHeaderCreateDto)
    {
        var order = new OrderHeader()
        {
            AppUserId = orderHeaderCreateDto.AppUserId,
            CustomerName = orderHeaderCreateDto.CustomerName,
            CustomerEmail = orderHeaderCreateDto.CustomerEmail,
            OrderTotalAmount = orderHeaderCreateDto.OrderTotalAmount,
            TotalCount = orderHeaderCreateDto.TotalCount,
            OrderDateTime = DateTime.UtcNow,
            Status = string.IsNullOrEmpty(orderHeaderCreateDto.Status) 
                ? SharedData.OrderStatus.Pending 
                : orderHeaderCreateDto.Status
        };

        await _dbContext.OrderHeaders.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        foreach (var orderDetailsCreateDto in orderHeaderCreateDto.OrderDetailsDtos)
        {
            var orderDetails = new OrderDetails()
            {
                OrderHeaderId = order.OrderHeaderId,
                ProductId = orderDetailsCreateDto.ProductId,
                Quantity = orderDetailsCreateDto.Quantity,
                ItemName = orderDetailsCreateDto.ItemName,
                Price = orderDetailsCreateDto.Price
            };

            await _dbContext.OrderDetails.AddAsync(orderDetails);
        }

        await _dbContext.SaveChangesAsync();

        await _dbContext
            .Entry(order)
            .Reference(o => o.User)
            .LoadAsync();
        
        return order;
    }


    public async Task<OrderHeader?> GetOrderByIdAsync(Guid id)
    {
        return await _dbContext
            .OrderHeaders
            .Include(items => items.OrderDetails)
            .ThenInclude(x => x.ProductId)
            .FirstOrDefaultAsync(u => u.OrderHeaderId == id);    
    }

    public async Task<IEnumerable<OrderHeader>> GetOrderByUserIdAsync(string userId)
    {
        var query = _dbContext
            .OrderHeaders
            .Include(items => items.OrderDetails)
            .ThenInclude(x => x.ProductId)
            .OrderByDescending(u => u.AppUserId);

        if (!string.IsNullOrEmpty(userId))
        {
            return await query
                .Where(u => u.AppUserId == userId)
                .ToListAsync();
        }

        return await query.ToListAsync();
    }

    public async Task<bool> UpdateOrderHeaderAsync(Guid id,
        OrderHeaderUpdateDto orderHeaderUpdateDto)
    {
        if (orderHeaderUpdateDto is null 
            || orderHeaderUpdateDto.OrderHeaderId != id)
        {
            return false;
        }

        var orderHeaderFromDb = await _dbContext
            .OrderHeaders
            .FirstOrDefaultAsync(u => u.OrderHeaderId == id);

        if (orderHeaderFromDb is null)
        {
            return false;
        }

        if (!string.IsNullOrEmpty(orderHeaderUpdateDto.CustomerName))
        {
            orderHeaderFromDb.CustomerName = orderHeaderUpdateDto.CustomerName;
        }
        
        if (!string.IsNullOrEmpty(orderHeaderUpdateDto.CustomerEmail))
        {
            orderHeaderFromDb.CustomerEmail = orderHeaderUpdateDto.CustomerEmail;
        }
        
        if (!string.IsNullOrEmpty(orderHeaderUpdateDto.Status))
        {
            orderHeaderFromDb.Status = orderHeaderUpdateDto.Status;
        }

        await _dbContext.SaveChangesAsync();

        return true;
    }
}