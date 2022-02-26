using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class Registration
    {
        public static IServiceCollection RegisterBusinessLogic(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
