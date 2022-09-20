using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Developers.Queries
{
    public class GetByIdDeveloperQuery : IRequest<GetByIdDeveloperDto>
    {
        public int Id { get; set; }

        public class GetByIdDeveloperQueryHandler : IRequestHandler<GetByIdDeveloperQuery, GetByIdDeveloperDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public GetByIdDeveloperQueryHandler(IDeveloperRepository developerRepository, IMapper mapper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<GetByIdDeveloperDto> Handle(GetByIdDeveloperQuery request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.DeveloperShouldExist(request.Id);

                Developer? developer = await _developerRepository.GetAsync(d => d.Id == request.Id, include: d => d.Include(opt => opt.User));
                GetByIdDeveloperDto getByIdDeveloperDto = _mapper.Map<GetByIdDeveloperDto>(developer);

                return getByIdDeveloperDto;
            }
        }
    }
}
