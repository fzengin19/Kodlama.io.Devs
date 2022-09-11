using Application.Features.Developers.Dtos;
using Core.Security.JWT;


namespace Application.Features.Users.Models
{
    public class CreatedUserModel
    {
        public AccessToken? AccessToken { get; set; }
        public CreatedUserDto? CreatedUserDto { get; set; }
        public CreatedUserModel()
        {
        }

        
    }
}
