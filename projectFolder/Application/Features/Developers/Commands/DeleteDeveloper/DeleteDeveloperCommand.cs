using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Developers.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommand : IRequest<DeletedDeveloperDto>
    {
        public int Id { get; set; }
        public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, DeletedDeveloperDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public DeleteDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<DeletedDeveloperDto> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.DeveloperShouldExist(request.Id);

                Developer mappedDeveloper = _mapper.Map<Developer>(request);
                Developer deletedDeveloper = await _developerRepository.DeleteAsync(mappedDeveloper);
                DeletedDeveloperDto deletedDeveloperDto = _mapper.Map<DeletedDeveloperDto>(deletedDeveloper);

                return deletedDeveloperDto;
            }
        }
    }
}
