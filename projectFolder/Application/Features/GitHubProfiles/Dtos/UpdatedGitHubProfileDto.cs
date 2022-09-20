using Domain.Entities;


namespace Application.Features.GitHubProfiles.Dtos
{
    public class UpdatedGitHubProfileDto
    {
        public int Id { get; set; }
        public string ProfileUrl { get; set; }
        public Developer Developer { get; set; }
    }
}
