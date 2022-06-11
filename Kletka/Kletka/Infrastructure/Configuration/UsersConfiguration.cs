using Kletka.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.FullName).IsRequired();
            builder.Property(u => u.Contacts).IsRequired();
            builder.Property(u => u.BirthDate).IsRequired();
            builder.Property(u => u.ProjectName).IsRequired();
            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.UserType).IsRequired();
            builder.Property(u => u.UserStatusId).IsRequired();

            builder
                .HasOne(u => u.Status)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.UserStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(a => a.Accident)
                .WithOne(u => u.Users)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasMany(u => u.Account)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
