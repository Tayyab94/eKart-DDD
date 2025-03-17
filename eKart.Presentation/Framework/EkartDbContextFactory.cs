using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using static eKart.Presentation.Constants.Constants.connections;
namespace eKart.Presentation.Framework
{
    public class EkartDbContextFactory : IDesignTimeDbContextFactory<EKartContext>
    {
        public EKartContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(connectionFile)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EKartContext>();

            if(args is not null  && args.Contains(TestConnection) is true)
            {
                 optionsBuilder.UseSqlServer(configuration.GetConnectionString(TestConnection));
            }
            else if (args is not null && args.Length is 1) 
                {
                optionsBuilder.UseSqlServer(args.Single());
                }else
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(defaultConnection));
            }

            return new EKartContext(optionsBuilder.Options);
        }
    }
}
