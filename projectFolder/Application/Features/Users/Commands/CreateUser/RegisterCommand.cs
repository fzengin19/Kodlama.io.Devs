
using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Features.Users.Models;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Developers.Commands.CreateDeveloper
{
    public class RegisterCommand : IRequest<RegisteredModel>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;


            public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper, IAuthService authService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
                _authService = authService;
            }

            public async Task<RegisteredModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserFirstNameEmptyCheck(request.UserForRegisterDto.FirstName);
                await _userBusinessRules.UserLastNameEmptyCheck(request.UserForRegisterDto.LastName);
                await _userBusinessRules.UserEmailEmptyCheck(request.UserForRegisterDto.Email);
                await _userBusinessRules.UserPasswordEmptyCheck(request.UserForRegisterDto.Password);
                await _userBusinessRules.UserPasswordMinSizeCheck(request.UserForRegisterDto.Password);
                await _userBusinessRules.UserEmailRepeatCheck(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);


                User mappedUser = mappedUser = _mapper.Map<User>(request.UserForRegisterDto);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                User createdUser = await _userRepository.AddAsync(mappedUser);


                RegisteredDto createdUserDto = _mapper.Map<RegisteredDto>(createdUser);

                RegisteredModel createdUserModel = new RegisteredModel();
                createdUserModel.CreatedUserDto = createdUserDto;
                createdUserModel.AccessToken = await _authService.CreateAccessToken(createdUser);
                createdUserModel.RefreshToken = await _authService.CreateRefreshToken(createdUser,request.IpAddress);
                createdUserModel.RefreshToken = await _authService.AddRefreshToken(createdUserModel.RefreshToken);

                return createdUserModel;

            }
        }
    }
}
