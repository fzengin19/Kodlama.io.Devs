using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommand : IRequest<CreatedDeveloperDto>
    {
        public int UserId { get; set; }

        public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, CreatedDeveloperDto>
        {
            private readonly IDeveloperRepository _developerRepository;
        
            private readonly IMapper _mapper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<CreatedDeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.UserShouldCheck(request.UserId);


                Developer developer = _mapper.Map<Developer>(request);
                Developer createdDeveloper = await _developerRepository.AddAsync(developer);
                var developerinfo = await _developerRepository.GetAsync(d => d.Id == developer.Id, include: m => m.Include(u => u.User));
                                             ;
                CreatedDeveloperDto createdDeveloperDto = _mapper.Map<CreatedDeveloperDto>(createdDeveloper);
                createdDeveloperDto.User = developerinfo.User;

                return createdDeveloperDto;
            }
        }
    }
}
