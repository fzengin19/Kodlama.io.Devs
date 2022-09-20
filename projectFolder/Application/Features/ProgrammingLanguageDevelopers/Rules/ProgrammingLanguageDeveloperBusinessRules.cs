using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguageDevelopers.Rules
{
    public class ProgrammingLanguageDeveloperBusinessRules
    {
        private readonly IProgrammingLanguageDeveloperRepository _programmingLanguageDeveloperRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageDeveloperBusinessRules(IProgrammingLanguageDeveloperRepository programmingLanguageDeveloperRepository, IDeveloperRepository developerRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageDeveloperRepository = programmingLanguageDeveloperRepository;
            _developerRepository = developerRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageDeveloperCanNotBeDuplicatedWhenInserted(int developerId, int programmingLanguageId) 
        {
            ProgrammingLanguageDeveloper? programmingLanguageDeveloper =await _programmingLanguageDeveloperRepository.GetAsync(c => c.ProgrammingLanguageId == programmingLanguageId && 
                                                                                                                                    c.DeveloperId == developerId);
            if (programmingLanguageDeveloper != null) throw new BusinessException("Programming language developer already exist");
        }
        public async Task ProgrammingLanguageDeveloperCanNotBeDuplicatedWhenUpdated(int programmingLanguageDeveloperId, int developerId, int programmingLanguageId)
        {
            ProgrammingLanguageDeveloper? programmingLanguageDeveloper = await _programmingLanguageDeveloperRepository.GetAsync(c => c.Id != programmingLanguageDeveloperId &&
                                                                                                                                     c.ProgrammingLanguageId == programmingLanguageId && 
                                                                                                                                     c.DeveloperId == developerId);
            if (programmingLanguageDeveloper != null) throw new BusinessException("Programming language developer already exist");
        }

        public async Task DeveloperShouldExist(int developerId)
        {
            Developer? Developer = await _developerRepository.GetAsync(c => c.Id == developerId);
            if (Developer == null) throw new BusinessException("Programming language developer does not exist");
        }

        public async Task ProgrammingLanguageShouldExist(int programmingLanguageId)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(c => c.Id == programmingLanguageId);
            if (programmingLanguage == null) throw new BusinessException("Programming language does not exist");
        }

        public async Task ProgrammingLanguageDeveloperShouldExist(int id)
        {
            ProgrammingLanguageDeveloper? programmingLanguage = await _programmingLanguageDeveloperRepository.GetAsync(c => c.Id == id);
            if (programmingLanguage == null) throw new BusinessException("Programming language developer does not exist");
        }

    }
}
