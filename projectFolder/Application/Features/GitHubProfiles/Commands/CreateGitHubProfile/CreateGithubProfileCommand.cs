using Application.Features.GitHubProfiles.Dtos;
using Application.Features.GitHubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.GitHubProfiles.Commands.CreateGitHubProfile
{
    public class CreateGithubProfileCommand : IRequest<CreatedGitHubProfileDto>
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string ProfileUrl { get; set; }
        public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreatedGitHubProfileDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GitHubProfileBusinnessRules _gitHubProfileBusinessRules;

            public CreateGithubProfileCommandHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, GitHubProfileBusinnessRules gitHubProfileBusinessRules)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
                _gitHubProfileBusinessRules = gitHubProfileBusinessRules;
            }

            public async Task<CreatedGitHubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
            {

                await _gitHubProfileBusinessRules.ProfileUrlShouldNotBeEmpty(request.ProfileUrl);
                await _gitHubProfileBusinessRules.DeveloperShouldExist(request.DeveloperId);
                GitHubProfile gitHubProfile = _mapper.Map<GitHubProfile>(request);
                GitHubProfile createdGitHubProfile = await _gitHubProfileRepository.AddAsync(gitHubProfile);
                CreatedGitHubProfileDto createdGitHubProfileDto = _mapper.Map<CreatedGitHubProfileDto>(createdGitHubProfile);

                return createdGitHubProfileDto;
            }
        }
    }
}
