using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System.Xml.Linq;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _technologyRepository = technologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }
        public async Task UpdateTechnologyCheck(int technologyId,int programmingLanguageId, string name)
        {
            Technology? technology = await _technologyRepository.GetAsync(d => d.ProgrammingLanguageId == programmingLanguageId && d.Name == name && d.Id!=technologyId);
            if (technology != null) throw new BusinessException("This technology is already available");
        }
        public async Task CreateTechnologyCheck(int programmingLanguageId,string name)
        {
           Technology? technology = await _technologyRepository.GetAsync(d => d.ProgrammingLanguageId == programmingLanguageId && d.Name == name);
            if (technology != null) throw new BusinessException("This technology is already available");
        }
        public async Task TechnologyNameCanNotBeEmpty(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new BusinessException("Technology name is cannot be empty");
        }

        public async Task TechnologyShouldExist(int id)
        {
            Technology? technology = await _technologyRepository.GetAsync(d => d.Id== id);
            if (technology == null) throw new BusinessException("Technology does not exist");
        }
    }
}
