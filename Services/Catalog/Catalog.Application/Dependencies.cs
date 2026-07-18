using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddMediatR(config=>{

                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
