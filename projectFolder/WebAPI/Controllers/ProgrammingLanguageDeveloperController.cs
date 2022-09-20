using Application.Features.ProgrammingLanguageDevelopers.Commands.CreateProgrammingLanguageDeveloperCommand;
using Application.Features.ProgrammingLanguageDevelopers.Commands.DeleteProgrammingLanguageDeveloper;
using Application.Features.ProgrammingLanguageDevelopers.Commands.UpdateProgrammingLanguageDeveloper;
using Application.Features.ProgrammingLanguageDevelopers.Dtos;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageDeveloperController : BaseController
    {

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageDeveloperCommand createTechnologyCommand)
        {
            CreatedProgrammingLanguageDeveloperDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageDeveloperCommand updateTechnologyCommand)
        {
           UpdatedProgrammingLanguageDeveloperDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageDeveloperCommand DeleteTechnologyCommand)
        {
            DeletedProgrammingLanguageDeveloperDto result = await Mediator.Send(DeleteTechnologyCommand);
            return Ok(result);
        }
    }
}
