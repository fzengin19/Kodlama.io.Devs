using Application.Features.Developers.Commands.CreateDeveloper;
using Application.Features.Developers.Dtos;
using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserCommand createUserCommand)
        {
            CreatedUserModel result = await Mediator.Send(createUserCommand);
            return Created("", result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            UserLoginDto result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
