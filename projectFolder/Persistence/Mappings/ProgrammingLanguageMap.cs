using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappings
{
    public class ProgrammingLanguageMap : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.HasKey(pl => pl.Id);
            builder.Property(pl => pl.Id).ValueGeneratedOnAdd();
            builder.Property(pl => pl.Name).IsRequired();
            builder.Property(pl => pl.Name).HasMaxLength(50);

            builder.ToTable("ProgrammingLanguages");

            builder.HasData( new(1, "C", new DateTime(1972, 1, 10), "Dennis Ritchie & Bell Labs"), new(2, "C++", new DateTime(1983, 1, 10), "Bjarne Stroustrup (Bell Labs)"), new(3, "C#", new DateTime(2000, 1, 10), "Mads Torgersen (Microsoft)"), new(4,"Java", new DateTime(1995,05,22), "James Gosling & Sun Microsystems") );
        }
    }
}
