using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Mappings
{
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
            builder.Property(u => u.UserId).HasColumnName("UserId");
            builder.HasOne(u => u.OperationClaim);
            builder.HasOne(u => u.User);

        }
    }
}
