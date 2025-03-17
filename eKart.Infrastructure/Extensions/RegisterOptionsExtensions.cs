using eKart.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Infrastructure.Extensions
{
    public static class RegisterOptionsExtensions
    {
        public static IServiceCollection RegisterOptions(this IServiceCollection service)
        {
            service.ConfigureOptions<DatabaseOptionsSetup>();

            return service;
;        }
    }
}
