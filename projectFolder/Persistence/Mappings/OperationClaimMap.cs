using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OpetationClaims").HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("Id");
            builder.Property(o => o.Name).HasColumnName("Name");
        }
    }
}
