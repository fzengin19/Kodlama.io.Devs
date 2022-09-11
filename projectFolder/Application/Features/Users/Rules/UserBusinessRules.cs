using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Developers.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserFirstNameEmptyCheck(string firstName)
        {
            if (String.IsNullOrEmpty(firstName)) throw new BusinessException("Firstname cannot be empty");
        }
        public async Task UserLastNameEmptyCheck(string lastName)
        {
            if (String.IsNullOrEmpty(lastName)) throw new BusinessException("Lastname cannot be empty");
        }
        public async Task UserEmailEmptyCheck(string email)
        {
            if (String.IsNullOrEmpty(email)) throw new BusinessException("Email cannot be empty");
        }
        public async Task UserEmailRepeatCheck(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("This email is already using");
        }
        public async Task UserPasswordEmptyCheck(string password)
        {
            if (String.IsNullOrEmpty(password)) throw new BusinessException("Password cannot be empty");
        }
        public async Task UserPasswordMinSizeCheck(string password)
        {
            if (password.Length<8) throw new BusinessException("The password must be at least 8 characters");
        }
 
    }
}
