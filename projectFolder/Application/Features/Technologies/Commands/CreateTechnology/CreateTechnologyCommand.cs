using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CrudTechnologyDto>
    {
        public int? ProgrammingLangugeId { get; set; }
        public string? Name { get; set; }
        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CrudTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CrudTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await  _technologyBusinessRules.NameEmptyCheck(request.Name);
                await  _technologyBusinessRules.ProgrammingLanguageIdEmptyCheck(request.ProgrammingLangugeId);
                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology createdTechnology= await _technologyRepository.AddAsync(mappedTechnology);
                CrudTechnologyDto createdTechnologyDto = _mapper.Map<CrudTechnologyDto>(createdTechnology);
                return createdTechnologyDto;
            }
        }

    }
}
