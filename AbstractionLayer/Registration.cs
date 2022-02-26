using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AbstractionLayer
{
    public static class Registration
    {
        public static IServiceCollection RegisterAbstractLayer(this IServiceCollection services)
        {
            //services.AddTransient<I>()
            return services;
        }

    }
}
