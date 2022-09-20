using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;


namespace Application.Features.GitHubProfiles.Rules
{
    public class GitHubProfileBusinnessRules
    {
        private readonly IDeveloperRepository _developerRepository;
        public async Task ProfileUrlShouldNotBeEmpty(string profileUrl)
        {
            if (String.IsNullOrEmpty(profileUrl)) throw new BusinessException("Profile url is cannot be empty");
        }

        public async Task DeveloperShouldExist(int developerId)
        {
           Developer? developer =   await _developerRepository.GetAsync(d => d.Id == developerId);
            if (developer == null) throw new BusinessException("Developer is not found");
        }

    }
}
