using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class TechnologyMap : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("Technologies").HasKey(t => t.Id); ;
  
            builder.Property(t => t.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Property(t => t.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            builder.HasOne<ProgrammingLanguage>(t => t.ProgrammingLanguage);
        }
    }
}
