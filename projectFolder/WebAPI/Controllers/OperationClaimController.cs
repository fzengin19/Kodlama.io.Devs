using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : BaseController
    {
        [HttpPost("create")]
        public async  Task<IActionResult> Create(CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateOperationClaimCommand updatedOperationClaimDto)
        {
            UpdatedOperationClaimDto result = await Mediator.Send(updatedOperationClaimDto);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaim result = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(result);
        }
    }
}
