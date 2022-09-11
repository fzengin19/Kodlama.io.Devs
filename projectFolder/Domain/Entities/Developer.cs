using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;


namespace Domain.Entities
{
    public class Developer :Entity
    {
        public int UserId { get; set; }
        public GitHubProfile? GitHubProfile { get; set; }
        public virtual User? User { get; set; }

        public Developer()
        {
                
        }
        public Developer(int userId)
        {
            UserId = userId;
        }

    }
}
