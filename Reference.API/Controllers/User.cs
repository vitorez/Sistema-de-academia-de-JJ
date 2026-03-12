using Microsoft.AspNetCore.Mvc;
using Reference.Application.DTOs;
using Reference.Application.Interface;

namespace Reference.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class User : ControllerBase
{
    private readonly IUser user;
    public User(IUser user)
    {
        this.user = user;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDTO loginDTO)
    {
        var result = await user.LoginUserAsync(loginDTO);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<LoginResponse>> RegisterUser(RegisterUserDTO registerUserDTO)
    {
        var result = await user.RegisterUserAsync(registerUserDTO);
        return Ok(result);
    }
}

