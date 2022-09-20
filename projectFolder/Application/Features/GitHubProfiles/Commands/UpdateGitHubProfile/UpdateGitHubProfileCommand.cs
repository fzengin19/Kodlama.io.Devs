using Application.Features.GitHubProfiles.Dtos;
using Application.Features.GitHubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile
{
    public class UpdateGitHubProfileCommand : IRequest<UpdatedGitHubProfileDto>
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string ProfileUrl { get; set; }


        public class UpdateGitHubProfileCommandHandler : IRequestHandler<UpdateGitHubProfileCommand, UpdatedGitHubProfileDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly GitHubProfileBusinnessRules  _gitHubProfileBusinnessRules;

            public UpdateGitHubProfileCommandHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, GitHubProfileBusinnessRules gitHubProfileBusinnessRules)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
                _gitHubProfileBusinnessRules = gitHubProfileBusinnessRules;
            }

            public async Task<UpdatedGitHubProfileDto> Handle(UpdateGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                await _gitHubProfileBusinnessRules.ProfileUrlShouldNotBeEmpty(request.ProfileUrl);
                await _gitHubProfileBusinnessRules.DeveloperShouldExist(request.Id);

                GitHubProfile gitHubProfile = _mapper.Map<GitHubProfile>(request);
                GitHubProfile updatedGitHubProfile = await _gitHubProfileRepository.UpdateAsync(gitHubProfile);
                UpdatedGitHubProfileDto crudGitHubProfileDto = _mapper.Map<UpdatedGitHubProfileDto>(updatedGitHubProfile);

                return crudGitHubProfileDto;
            }
        }
    }
}
