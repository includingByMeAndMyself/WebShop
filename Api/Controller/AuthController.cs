using System.Net;
using Api.Common;
using Api.Data;
using Api.Model;
using Api.ModelDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller;

public class AuthController : StoreController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(
        AppDbContext dbContext,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager)
        : base(dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] RegisterRequestDto requestDto)
    {
        if (requestDto is null)
        {
            return BadRequest(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Неккоректная модель запроса" }
            });
        }

        var userFromDb = await dbContext
            .AppUsers
            .FirstOrDefaultAsync(u =>
                u.UserName.ToLower() == requestDto.UserName.ToLower());

        if (userFromDb != null)
        {
            return BadRequest(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Такой пользователь уже существует" }
            });
        }

        var newAppUser = new AppUser()
        {
            UserName = requestDto.UserName,
            Email = requestDto.Email,
            NormalizedEmail = requestDto.Email.ToUpper()
        };

        var result = await _userManager.CreateAsync(
            newAppUser, requestDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new ResponseServer()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = result.Errors.Select(e => e.Description).ToList()
            });
        }

        var newRoleAppUser = requestDto.Role.Equals(
            SharedData.Role.Admin, StringComparison.OrdinalIgnoreCase)
            ? SharedData.Role.Admin
            : SharedData.Role.Consumer;

        await _userManager.AddToRoleAsync(newAppUser, newRoleAppUser);
        
        return Ok(new ResponseServer()
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Регистрация завершена"
        });
    }
}