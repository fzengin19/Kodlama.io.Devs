using Application.Features.ProgrammingLanguageDevelopers.Dtos;
using Application.Features.ProgrammingLanguageDevelopers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguageDevelopers.Commands.UpdateProgrammingLanguageDeveloper
{
    public class UpdateProgrammingLanguageDeveloperCommand : IRequest<UpdatedProgrammingLanguageDeveloperDto>
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public class UpdateProgrammingLanguageDeveloperCommandHandler : IRequestHandler<UpdateProgrammingLanguageDeveloperCommand, UpdatedProgrammingLanguageDeveloperDto>
        {
            private readonly IProgrammingLanguageDeveloperRepository _programmingLanguageDeveloperRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageDeveloperBusinessRules _programmingLanguageDeveloperBusinessRules;

            public UpdateProgrammingLanguageDeveloperCommandHandler(IProgrammingLanguageDeveloperRepository programmingLanguageDeveloperRepository, IMapper mapper, ProgrammingLanguageDeveloperBusinessRules programmingLanguageDeveloperBusinessRules)
            {
                _programmingLanguageDeveloperRepository = programmingLanguageDeveloperRepository;
                _mapper = mapper;
                _programmingLanguageDeveloperBusinessRules = programmingLanguageDeveloperBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDeveloperDto> Handle(UpdateProgrammingLanguageDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageDeveloperBusinessRules.DeveloperShouldExist(request.DeveloperId);
                await _programmingLanguageDeveloperBusinessRules.ProgrammingLanguageShouldExist(request.ProgrammingLanguageId);
                await _programmingLanguageDeveloperBusinessRules.ProgrammingLanguageDeveloperShouldExist(request.Id);
                await _programmingLanguageDeveloperBusinessRules.ProgrammingLanguageDeveloperCanNotBeDuplicatedWhenUpdated(request.Id,request.DeveloperId,request.ProgrammingLanguageId);

                ProgrammingLanguageDeveloper mappedprogrammingLanguageDeveloper = _mapper.Map<ProgrammingLanguageDeveloper>(request);
                ProgrammingLanguageDeveloper updatedProgrammingLanguageDeveloper = await _programmingLanguageDeveloperRepository.UpdateAsync(mappedprogrammingLanguageDeveloper);
                ProgrammingLanguageDeveloper programmingLanguageDeveloper = await _programmingLanguageDeveloperRepository.GetAsync(c => c.Id == updatedProgrammingLanguageDeveloper.Id, include: m => m
                    .Include(c => c.Developer)
                    .Include(c => c.ProgrammingLanguage)
                    );


                UpdatedProgrammingLanguageDeveloperDto mappedProgrammingLanguageDeveloperDto = _mapper.Map<UpdatedProgrammingLanguageDeveloperDto>(programmingLanguageDeveloper);
                return mappedProgrammingLanguageDeveloperDto;

            }
        }
    }
}
