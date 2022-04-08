using Kletka.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Accidents> Accidents { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new AccountsConfiguration());
            modelBuilder.ApplyConfiguration(new AccidentsConfiguration());
            modelBuilder.ApplyConfiguration(new StatusesConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
