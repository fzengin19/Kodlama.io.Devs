
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Mappings;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ProgrammingLanguageDeveloper> ProgrammingLanguageDevelopers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProgrammingLanguageMap());
            modelBuilder.ApplyConfiguration(new TechnologyMap());
            modelBuilder.ApplyConfiguration(new ProgrammingLanguageDeveloperMap());
            modelBuilder.ApplyConfiguration(new DeveloperMap());
            modelBuilder.ApplyConfiguration(new GitHubProfileMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserOperationClaimMap());
            modelBuilder.ApplyConfiguration(new OperationClaimMap());
        }
    }
}
