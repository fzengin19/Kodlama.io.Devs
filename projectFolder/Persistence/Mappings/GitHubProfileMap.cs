using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class GitHubProfileMap : IEntityTypeConfiguration<GitHubProfile>
    {
        public void Configure(EntityTypeBuilder<GitHubProfile> builder)
        {
            builder.ToTable("GitHubProfiles").HasKey(g => g.Id);
            builder.Property(g => g.GitHubUrl).HasColumnName("GitHubUrl");
            builder.Property(g => g.DeveloperId).HasColumnName("DeveloperId");
            builder.HasOne<Developer>(g => g.Developer);
        }
    }
}
