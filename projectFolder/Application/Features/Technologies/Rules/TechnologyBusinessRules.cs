using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public TechnologyBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageIdEmptyCheck(int? programmingLanguageId)
        {
            if (programmingLanguageId == null) throw new BusinessException("Programming language id cannot be empty");
        }
        public async Task NameEmptyCheck(string? name)
        {
            if (String.IsNullOrEmpty(name)) throw new BusinessException("Tenhnology name cannot be empty");
        }
        public async Task ProgrammingLanguageCheck(int id)
        {
            var pl =  await _programmingLanguageRepository.GetAsync(t => t.Id == id);
            if (pl == null) throw new BusinessException("Programming language is not found");
        }
    }
}
