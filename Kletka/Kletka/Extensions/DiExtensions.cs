using Kletka.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Extensions
{
    public static class DiExtensions
    {
        public static void AddSQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MVCDbContext>(options =>
            {
                //options.UseSqlServer(
                //        configuration.GetConnectionString("SqlDatabase"),
                //        b => b.MigrationsAssembly(typeof(MVCDbContext).Assembly.FullName))
                //    .UseLazyLoadingProxies();

                options.UseMySql(configuration.GetConnectionString("SqlDatabase"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
            );
        }
    }
}
