using Kletka.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Configuration
{
    public class AccidentsConfiguration : IEntityTypeConfiguration<Accidents>
    {
        public void Configure(EntityTypeBuilder<Accidents> builder)
        {
            builder.Property(u => u.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.AccidentTime).IsRequired();
            builder.Property(u => u.AccidentStatus).IsRequired();
            builder.Property(u => u.AccidentComment).IsRequired();

            builder.Property(u => u.Accident).IsRequired();

        }
    }
}
