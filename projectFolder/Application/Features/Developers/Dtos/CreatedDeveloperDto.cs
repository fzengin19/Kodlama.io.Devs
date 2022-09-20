

using Core.Security.Entities;

namespace Application.Features.Developers.Dtos
{
    public class CreatedDeveloperDto
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
