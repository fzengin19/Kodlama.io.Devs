using Application.Features.Developers.Dtos;
using Application.Features.GitHubProfiles.Dtos;
using Application.Features.GitHubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile
{
    public class DeleteGitHubProfileCommand : IRequest<DeletedGitHubProfileDto>
    {
        public int Id { get; set; }

        public class DeleteGitHubProfileCommandHandler : IRequestHandler<DeleteGitHubProfileCommand, DeletedGitHubProfileDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GitHubProfileBusinnessRules _gitHubProfileBusinnessRules;
            public async Task<DeletedGitHubProfileDto> Handle(DeleteGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                await _gitHubProfileBusinnessRules.DeveloperShouldExist(request.Id);

                GitHubProfile gitHubProfile = _mapper.Map<GitHubProfile>(request);
                GitHubProfile deletedGitHubProfile = await _gitHubProfileRepository.DeleteAsync(gitHubProfile);
                DeletedGitHubProfileDto deletedGitHubProfileDto = _mapper.Map<DeletedGitHubProfileDto>(deletedGitHubProfile);

                return deletedGitHubProfileDto;
            }
        }
    }
}
