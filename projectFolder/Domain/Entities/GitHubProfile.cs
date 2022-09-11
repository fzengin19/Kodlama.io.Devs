using Core.Persistence.Repositories;


namespace Domain.Entities
{
    public class GitHubProfile : Entity
    {
        public int DeveloperId { get; set; }
        public string GitHubUrl { get; set; }
        public virtual Developer? Developer { get; set; }

        public GitHubProfile()
        {

        }
        public GitHubProfile(int id, int developerId, string gitHubUrl)
        {
            Id = id;
            DeveloperId = developerId;
            GitHubUrl = gitHubUrl;
        }

   
    }
}
