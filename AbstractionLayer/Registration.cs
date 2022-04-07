using AbstractionLayer.Repository;
using AbstractionLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AbstractionLayer
{
    public static class Registration
    {
        public static IServiceCollection RegisterAbstractLayer(this IServiceCollection services)
        {
            services.AddTransient<IBankCardRepository, BankCardRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            return services;
        }

    }
}
