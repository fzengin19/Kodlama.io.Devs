using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Entities
{
    public class Developer :Entity
    {
        public int UserId { get; set; }
        public GitHubProfile? GitHubProfile { get; set; }
        public IEnumerable<ProgrammingLanguageDeveloper> ProgrammingLanguageDevelopers { get; set; }
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
