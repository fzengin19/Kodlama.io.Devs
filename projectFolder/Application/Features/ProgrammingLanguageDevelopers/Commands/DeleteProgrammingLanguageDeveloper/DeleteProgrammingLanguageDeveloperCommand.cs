using Application.Features.ProgrammingLanguageDevelopers.Dtos;
using Application.Features.ProgrammingLanguageDevelopers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.ProgrammingLanguageDevelopers.Commands.DeleteProgrammingLanguageDeveloper
{
    public class DeleteProgrammingLanguageDeveloperCommand : IRequest<DeletedProgrammingLanguageDeveloperDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageDeveloperCommandHandler : IRequestHandler<DeleteProgrammingLanguageDeveloperCommand, DeletedProgrammingLanguageDeveloperDto>
        {
            private readonly IProgrammingLanguageDeveloperRepository _programmingLanguageDeveloperRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageDeveloperBusinessRules _programmingLanguageDeveloperBusinessRules;
            public async Task<DeletedProgrammingLanguageDeveloperDto> Handle(DeleteProgrammingLanguageDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageDeveloperBusinessRules.ProgrammingLanguageDeveloperShouldExist(request.Id);



                ProgrammingLanguageDeveloper programmingLanguageDeveloper = await _programmingLanguageDeveloperRepository.GetAsync(c => c.Id == request.Id, include: m => m
                    .Include(c => c.Developer)
                    .Include(c => c.ProgrammingLanguage)
                    );

                ProgrammingLanguageDeveloper mappedProgrammingLanguageDeveloper = _mapper.Map<ProgrammingLanguageDeveloper>(request);

                _programmingLanguageDeveloperRepository.DeleteAsync(mappedProgrammingLanguageDeveloper);
                DeletedProgrammingLanguageDeveloperDto mappedProgrammingLanguageDeveloperDto = _mapper.Map<DeletedProgrammingLanguageDeveloperDto>(programmingLanguageDeveloper);
                return mappedProgrammingLanguageDeveloperDto;



                throw new NotImplementedException();
            }
        }
    }
}
