using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }
        public async Task ProgrammingLanguageIdEmptyCheck(int id)
        {
            if (Int32.MinValue == id) throw new BusinessException("Programming language name cannot be empty.");
        }

        public async Task ProgrammingLanguageNameEmptyCheck(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new BusinessException("Programming language name cannot be empty.");
        }
        public async Task ProgrammingLanguageDeveloperEmptyCheck(string developer)
        {
            if (String.IsNullOrEmpty(developer)) throw new BusinessException("Programming language developer cannot be empty.");
        }
        public async Task ProgrammingLanguageDevelopmentDateEmptyCheck(DateTime developmentDate)
        {
            if (developmentDate == DateTime.MinValue) throw new BusinessException("Programming language development date cannot be empty.");
        }


        public async Task ProgrammingLanguageNameRepeatCheck(string name)
        {
            ProgrammingLanguage result = await _programmingLanguageRepository.GetAsync(pl => pl.Name == name);
            if (result != null) throw new BusinessException("Programming language name already exists.");
        }


        public async Task ProgrammingLanguageNameRepeatCheckOnUpdate(int id, string name)
        {
            ProgrammingLanguage result = await _programmingLanguageRepository.GetAsync(pl => pl.Id != id  && pl.Name == name);
            if (result != null) throw new BusinessException("Programming language name already exists.");
        }
       
    }
}
