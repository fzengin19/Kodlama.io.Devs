using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand :IRequest<CrudTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string? Name { get; set; }
        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, CrudTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CrudTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.NameEmptyCheck(request.Name);
                await _technologyBusinessRules.ProgrammingLanguageIdEmptyCheck(request.ProgrammingLanguageId);
                await _technologyBusinessRules.ProgrammingLanguageCheck(request.Id);

                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);

                CrudTechnologyDto crudTechnologyDto = _mapper.Map<CrudTechnologyDto>(updatedTechnology);

                return crudTechnologyDto;
            }
        }
    }
}
