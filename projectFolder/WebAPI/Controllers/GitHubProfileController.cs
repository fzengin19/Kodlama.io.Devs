using Application.Features.Developers.Dtos;
using Application.Features.Developers.Queries;
using Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile;
using Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Application.Features.GitHubProfiles.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubProfileController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateGithubProfileCommand  createGitHubProfileCommand)
        {
            CreatedGitHubProfileDto result = await Mediator.Send(createGitHubProfileCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGitHubProfileCommand createGitHubProfileCommand)
        {
            UpdatedGitHubProfileDto result = await Mediator.Send(createGitHubProfileCommand);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteGitHubProfileCommand createGitHubProfileCommand)
        {
            DeletedGitHubProfileDto result = await Mediator.Send(createGitHubProfileCommand);
            return Ok(result);
        }
    }
}
