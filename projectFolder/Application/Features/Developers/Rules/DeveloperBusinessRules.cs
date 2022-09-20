using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;


namespace Application.Features.Developers.Rules
{
    public class DeveloperBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperBusinessRules(IUserRepository userRepository, IDeveloperRepository developerRepository)
        {
            _userRepository = userRepository;
            _developerRepository = developerRepository;
        }

        public async Task DeveloperShouldExist(int id)
        {
            Developer? checkedDeveloper = await _developerRepository.GetAsync(d => d.Id == id);
            if (checkedDeveloper == null) throw new BusinessException("Developer is not found");
        }

        public async Task UserShouldCheck(int userId) 
        {
            User? user = await _userRepository.GetAsync(u => u.Id == userId);
            if (user == null) throw new BusinessException("User not found");
        } 
    }
}
