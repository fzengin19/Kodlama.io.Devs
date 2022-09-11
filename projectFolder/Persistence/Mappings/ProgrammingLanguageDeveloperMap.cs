using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class ProgrammingLanguageDeveloperMap : IEntityTypeConfiguration<ProgrammingLanguageDeveloper>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguageDeveloper> builder)
        {
            builder.ToTable("ProgrammingLanguageDevelopers").HasKey(d => d.Id);
            builder.Property(d => d.DeveloperId).HasColumnName("DeveloperId");
            builder.Property(d => d.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            builder.HasOne<Developer>(d => d.Developer);
            builder.HasOne<ProgrammingLanguage>(d => d.ProgrammingLanguage);
        }
    }
}
