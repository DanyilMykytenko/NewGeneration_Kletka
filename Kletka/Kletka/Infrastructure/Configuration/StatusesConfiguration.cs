using Kletka.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Configuration
{
    public class StatusesConfiguration : IEntityTypeConfiguration<Statuses>
    {
        public void Configure(EntityTypeBuilder<Statuses> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Status).IsRequired();
        }
    }
}
