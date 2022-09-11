using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class ProgrammingLanguageDeveloperRepository : EfRepositoryBase<ProgrammingLanguageDeveloper,BaseDbContext> ,IProgrammingLanguageDeveloperRepository
    {
        public ProgrammingLanguageDeveloperRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
