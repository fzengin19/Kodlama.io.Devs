
using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Developers.Commands.CreateDeveloper
{
    public class CreateUserCommand : IRequest<CreatedUserModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;


            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<CreatedUserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserFirstNameEmptyCheck(request.FirstName);
                await _userBusinessRules.UserLastNameEmptyCheck(request.LastName);
                await _userBusinessRules.UserEmailEmptyCheck(request.Email);
                await _userBusinessRules.UserPasswordEmptyCheck(request.Password);
                await _userBusinessRules.UserPasswordMinSizeCheck(request.Password);
                await _userBusinessRules.UserEmailRepeatCheck(request.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);


                User mappedUser = mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                User createdUser = await _userRepository.AddAsync(mappedUser);
                CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);

                CreatedUserModel createdUserModel = new CreatedUserModel();
                createdUserModel.CreatedUserDto = createdUserDto;
                var token = _tokenHelper.CreateToken(mappedUser, new List<OperationClaim>());

                createdUserModel.AccessToken = token;

                return createdUserModel;

            }
        }
    }
}
