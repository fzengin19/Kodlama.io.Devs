using Domain.Entities;

using Persistence.Contexts;
using Application.Services.Repositories;
using Core.Persistence.Repositories;

namespace Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage,BaseDbContext>,IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
