using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Mappings
{
    public class DeveloperMap : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developer").HasKey(d => d.Id);
            builder.HasOne<GitHubProfile>(d => d.GitHubProfile);

        }
    }
}
