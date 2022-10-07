using Core.Security.JWT;

namespace Application.Features.Users.Dtos
{
    public class LoginedUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccessToken? AccessToken { get; set; }
    }
}
