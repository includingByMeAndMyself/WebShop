using System.Net;
using Api.Data;
using Api.Model;
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
}