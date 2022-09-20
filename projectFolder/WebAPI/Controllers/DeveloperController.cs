using Application.Features.Developers.Commands.CreateDeveloper;
using Application.Features.Developers.Commands.DeleteDeveloper;
using Application.Features.Developers.Commands.UpdateDeveloper;
using Application.Features.Developers.Dtos;
using Application.Features.Developers.Queries;
using Application.Features.ProgrammingLanguages.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : BaseController
    {



        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDeveloperCommand createDeveloperCommand)
        {
            CreatedDeveloperDto result = await Mediator.Send(createDeveloperCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateDeveloperCommand updateDeveloperCommand)
        {
            UpdatedDeveloperDto result = await Mediator.Send(updateDeveloperCommand);
            return Ok( result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteDeveloperCommand deleteDeveloperCommand)
        {
            DeletedDeveloperDto result = await Mediator.Send(deleteDeveloperCommand);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            GetByIdDeveloperQuery getByIdDeveloperQuery = new GetByIdDeveloperQuery { Id = id };
            GetByIdDeveloperDto result = await Mediator.Send(getByIdDeveloperQuery);
            return Ok(result);
        }
    }
}
