using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class Registration
    {
        public static IServiceCollection RegisterBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<IBankCardServices, BankCardServices>();
            return services;
        }
    }
}
