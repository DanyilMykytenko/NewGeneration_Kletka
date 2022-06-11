using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kletka.Models
{
    public class DBManager : DbContext
    {
       // public DbSet<Manager> Users { get; set; }
       //
       // public DBManager()
       // {
       //     Database.EnsureCreated();
       // }
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
       //
       //     optionsBuilder.UseMySql(
       //         "server=localhost;user=root;password=DanyilMykytenko;database=test;",
       //         new MySqlServerVersion(new Version(8, 0, 28)),
       //         o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
       // }
    }
}
