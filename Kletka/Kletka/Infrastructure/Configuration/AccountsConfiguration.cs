using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kletka.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Configuration
{
    public class AccountsConfiguration : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.OwnerId).IsRequired();
            builder.Property(u => u.AccountNumber).IsRequired();
            builder.Property(u => u.Type).IsRequired();
            builder.Property(u => u.APIKey).IsRequired();
            builder.Property(u => u.CVVCode).IsRequired();
            builder.Property(u => u.AccountStatus).IsRequired();
        }
    }
}
