using Kletka.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Configuration
{
    public class TransactionsConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.TransactionDatetime).IsRequired();
            builder.Property(u => u.SendersAccountId)
                .HasColumnName("SendersAccount")
                .IsRequired();
            builder.Property(u => u.ReceiversAccountId)
                .HasColumnName("ReceiversAccount")
                .IsRequired();
            builder.Property(u => u.TransactionAmount).IsRequired();
            builder.Property(u => u.TransactionDescription).IsRequired();
            builder.Property(u => u.TransactionStatus).IsRequired();
            builder.Property(u => u.ErrorMessage).IsRequired();

            builder
                .HasOne(u => u.SendersAccount)
                .WithMany(u => u.SendedTransactions)
                .HasForeignKey(u => u.SendersAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(u => u.ReceiversAccount)
                .WithMany(u => u.ReceivedTransactions)
                .HasForeignKey(u => u.ReceiversAccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
