using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class GitHubProfileRepository : EfRepositoryBase<GitHubProfile,BaseDbContext> , IGitHubProfileRepository
    {
        public GitHubProfileRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
