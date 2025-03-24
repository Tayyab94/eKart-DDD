using eKart.Presentation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart_App.Extensions
{
    public static class RegisterControllerExtension
    {
        public static IServiceCollection RegisterControllers(this IServiceCollection services)
        {
            //services.AddControllers().AddApplicationPart(typeof(eKart.Presentation.Controllers.ProductController).Assembly);

            services.AddControllers().AddApplicationPart(AssemblyRefernce.assembly);
            return services;
        }
    }
}
