using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System.Security.Claims;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }
        public async Task OperationClaimCanNotBeDuplicatedWhenRegistered(string name)
        {
           OperationClaim? operationClaim= await _operationClaimRepository.GetAsync(op => op.Name == name);
            if (operationClaim != null) throw new BusinessException("Operation claim already exist");
        }
        public async Task OperationClaimCanNotBeDuplicatedWhenUpdate(int id, string name)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(op => op.Id != id && op.Name == name);
            if (operationClaim != null) throw new BusinessException("Operation claim already exist");
        }
        public async Task OperationClaimNameCanNotBeEmpty(string name)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(op => op.Name == name);
            if (operationClaim != null) throw new BusinessException("Operation claim name cannot be empty");
        }

        public async Task OperationClaimShouldExist(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(op => op.Id == id);
            if (operationClaim != null) throw new BusinessException("Operation claim not found");
        }

    }
}
