using eKart.Infrastructure.Options;
using eKart.Persistence.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Persistence.Extensions
{
    public static class DatabaseRegisterExtensions
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            services.AddDbContextPool<EKartContext>((serviceProvider, options) =>
            {

                var databaseOptions= serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

                options.UseSqlServer(databaseOptions.ConnectionString!, opt =>
                {
                    opt.CommandTimeout(databaseOptions.CommandTimeout);
                    opt.EnableRetryOnFailure(databaseOptions.MaxRetryCount,
                        TimeSpan.FromSeconds(databaseOptions.MaxrRetryDelay), Array.Empty<int>());
                });
            });

            return services;
        
        }
    }
}
