using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries
{
    public class GetProgrammingLanguageQuery : IRequest<GetProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class GetProgrammingLanguageQueryHandler : IRequestHandler<GetProgrammingLanguageQuery, GetProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<GetProgrammingLanguageDto> Handle(GetProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
               ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);
                GetProgrammingLanguageDto getProgrammingLanguageDto = _mapper.Map<GetProgrammingLanguageDto>(programmingLanguage);

                return getProgrammingLanguageDto;

            }
        }
    }
}
