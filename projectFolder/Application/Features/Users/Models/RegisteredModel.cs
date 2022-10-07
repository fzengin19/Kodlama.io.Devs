using Application.Features.Developers.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;


namespace Application.Features.Users.Models
{
    public class RegisteredModel
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public RegisteredDto CreatedUserDto { get; set; }
        public RegisteredModel()
        {
        }

        
    }
}
