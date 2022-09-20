using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommand : IRequest<UpdatedDeveloperDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, UpdatedDeveloperDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public UpdateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<UpdatedDeveloperDto> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.DeveloperShouldExist(request.Id);
                Developer mappedDeveloper = _mapper.Map<Developer>(request);
                Developer updatedDeveloper = await _developerRepository.UpdateAsync(mappedDeveloper);
                UpdatedDeveloperDto updatedDeveloperDto = _mapper.Map<UpdatedDeveloperDto>(updatedDeveloper);

                return updatedDeveloperDto;

            }
        }
    }
}
