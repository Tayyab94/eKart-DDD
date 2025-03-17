using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Infrastructure.Options
{
    public class DatabaseOptionsSetup(IConfiguration configuration, IWebHostEnvironment env) :
        IConfigureOptions<DatabaseOptions>
    {

        private const string _sectionName = "DatabaseOptions";
        private const string _connectionStringName = "ConnectionString";
        private const string _dafaultConnection = "DefaultConnection";
        private const string _testConnection = "TestConnection";


        public void Configure(DatabaseOptions options)
        {
            if (env.IsProduction() is true)
            {
                options.ConnectionString = configuration.GetConnectionString(_dafaultConnection);
            }
            else if (env.IsDevelopment() is true)
            {
                options.ConnectionString = configuration.GetConnectionString(_testConnection);
            }
            configuration.GetSection(_sectionName).Bind(options);
        }
    }
}
