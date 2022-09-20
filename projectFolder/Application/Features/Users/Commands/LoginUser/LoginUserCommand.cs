using Application.Features.Developers.Rules;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserLoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly UserBusinessRules _userBusinessRules;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<UserLoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserEmailEmptyCheck(request.Email);
                await _userBusinessRules.UserPasswordMinSizeCheck(request.Password);
                await _userBusinessRules.UserPasswordEmptyCheck(request.Password);

                User? user = await _userRepository.GetAsync(
                u => u.Email == request.Email,
                include: m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim));
                if (user == null) throw new AuthorizationException("Wrong email");

                List<OperationClaim> operationClaims = new List<OperationClaim>();

                foreach (var userOperationClaim in user.UserOperationClaims)
                {
                    operationClaims.Add(userOperationClaim.OperationClaim);
                }

                
                bool result = HashingHelper.VerifyPasswordHash(request.Password,user.PasswordHash,user.PasswordSalt);
                if (!result) throw new AuthorizationException("Wrong password");


                //UserLoginDto userLoginDto = new UserLoginDto();
                //userLoginDto.AccessToken = _tokenHelper.CreateToken(user, operationClaims);
                //userLoginDto.Id = user.Id;
                //userLoginDto.Name = user.FirstName + " " + user.LastName;
                //return userLoginDto;
                UserLoginDto userLoginDto = _mapper.Map<UserLoginDto>(user);

                var token = _tokenHelper.CreateToken(user, new List<OperationClaim>());

                userLoginDto.AccessToken = token;
               

                return userLoginDto;


            }
        }
    }
}
