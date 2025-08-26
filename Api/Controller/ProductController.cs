using System.Net;
using Api.Data;
using Api.Model;
using Api.ModelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller;

public class ProductController : StoreController
{
    public ProductController(AppDbContext dbContext) : base(dbContext)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var response = new ResponseServer()
        {
            StatusCode = HttpStatusCode.OK,
            Result = await dbContext.Products.ToListAsync()
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> FetchProductsWithPagination(
        int skip = 0, int take = 5)
    {
        var product = await dbContext
            .Products
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        
        var response = new ResponseServer()
        {
            StatusCode = HttpStatusCode.OK,
            Result = product
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        var response = new ResponseServer();

        if (product is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.IsSuccess = false;
            return NotFound(response);
        }

        response.StatusCode = HttpStatusCode.OK;
        response.Result = product;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseServer>> CreateProduct(
        [FromBody] ProductCreateDto product)
    {
        Product item = new Product()
        {
            Name = product.Name,
            Descritopr = product.Descritopr,
            Category = product.Category,
            Image = product.Image,
            Price = product.Price
        };

        await dbContext.AddAsync(item);
        await dbContext.SaveChangesAsync();

        return Created();
    }

    [HttpPut]
    public async Task<ActionResult<ResponseServer>> UpdateProduct(
        [FromQuery] Guid id, [FromBody] ProductUpdateDto product)
    {
        var productFromDb = await dbContext.Products.FindAsync(id);
        if (productFromDb is null)
        {
            return NotFound(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound
            });
        }

        productFromDb.Name = product.Name;
        productFromDb.Descritopr = product.Descritopr;
        productFromDb.Category = product.Category;
        productFromDb.Image = product.Image;
        productFromDb.Price = product.Price;

        dbContext.Products.Update(productFromDb);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult<ResponseServer>> DeleteProduct(
        [FromBody] Guid id)
    {
        try
        {
            if (id != null)
            {
                return BadRequest(new ResponseServer()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Невалидный Id" }
                });
            }

            var productFromDb = await dbContext.Products.FindAsync(id);
            if (productFromDb is null)
            {
                return NotFound(new ResponseServer()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = { "Продукт по id не найден" }
                });
            }

            dbContext.Products.Remove(productFromDb);
            await dbContext.SaveChangesAsync();

            return Ok(new ResponseServer()
            {
                StatusCode = HttpStatusCode.NoContent
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
}