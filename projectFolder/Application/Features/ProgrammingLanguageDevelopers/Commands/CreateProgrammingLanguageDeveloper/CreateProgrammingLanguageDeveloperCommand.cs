using Application.Features.ProgrammingLanguageDevelopers.Dtos;
using Application.Features.ProgrammingLanguageDevelopers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.ProgrammingLanguageDevelopers.Commands.CreateProgrammingLanguageDeveloperCommand
{
    public class CreateProgrammingLanguageDeveloperCommand : IRequest<CreatedProgrammingLanguageDeveloperDto>
    {
        public int DeveloperId { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateProgrammingLanguageDeveloperCommandHandler : IRequestHandler<CreateProgrammingLanguageDeveloperCommand, CreatedProgrammingLanguageDeveloperDto>
        {
            private readonly IProgrammingLanguageDeveloperRepository _programmingLanguageDeveloperRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageDeveloperBusinessRules _programmingLanguageDeveloperBusinessRules;

            public CreateProgrammingLanguageDeveloperCommandHandler(IProgrammingLanguageDeveloperRepository programmingLanguageDeveloperRepository, IMapper mapper, ProgrammingLanguageDeveloperBusinessRules programmingLanguageDeveloperBusinessRules)
            {
                _programmingLanguageDeveloperRepository = programmingLanguageDeveloperRepository;
                _mapper = mapper;
                _programmingLanguageDeveloperBusinessRules = programmingLanguageDeveloperBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageDeveloperDto> Handle(CreateProgrammingLanguageDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageDeveloperBusinessRules.ProgrammingLanguageShouldExist(request.ProgrammingLanguageId);
                await _programmingLanguageDeveloperBusinessRules.DeveloperShouldExist(request.DeveloperId);
                await _programmingLanguageDeveloperBusinessRules.ProgrammingLanguageDeveloperCanNotBeDuplicatedWhenInserted(request.DeveloperId,request.ProgrammingLanguageId);
                ProgrammingLanguageDeveloper mappedprogrammingLanguageDeveloper = _mapper.Map<ProgrammingLanguageDeveloper>(request);
                ProgrammingLanguageDeveloper  createdProgrammingLanguageDeveloper = await _programmingLanguageDeveloperRepository.AddAsync(mappedprogrammingLanguageDeveloper);
                ProgrammingLanguageDeveloper programmingLanguageDeveloper = await _programmingLanguageDeveloperRepository.GetAsync(c => c.Id == createdProgrammingLanguageDeveloper.Id,include: m => m
                    .Include(c => c.Developer )
                    .Include(c => c.ProgrammingLanguage)
                    );


                CreatedProgrammingLanguageDeveloperDto mappedProgrammingLanguageDeveloperDto = _mapper.Map<CreatedProgrammingLanguageDeveloperDto>(programmingLanguageDeveloper);
                return mappedProgrammingLanguageDeveloperDto;

            }
        }
    }
}
