using Domain.Entities;


namespace Application.Features.Developers.Dtos
{
    public class GetByIdDeveloperDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public GitHubProfile GitHubProfile { get; set; }
    }
}
