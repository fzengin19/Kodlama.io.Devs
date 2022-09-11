using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Mappings
{
    public class ProgrammingLanguageMap : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.ToTable("ProgrammingLanguages").HasKey(pl => pl.Id);
            builder.Property(pl => pl.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(pl => pl.Name).HasColumnName("Name").HasMaxLength(50);
            builder.HasMany(pl => pl.Technologies);

            builder.HasData( new(1, "C", new DateTime(1972, 1, 10)), new(2, "C++", new DateTime(1983, 1, 10)), new(3, "C#", new DateTime(2000, 1, 10)), new(4,"Java", new DateTime(1995,05,22)));
        }
    }
}
