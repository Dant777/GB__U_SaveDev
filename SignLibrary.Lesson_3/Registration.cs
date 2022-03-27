
using Microsoft.Extensions.DependencyInjection;

namespace SignLibrary.Lesson_3
{
    public static class Registration
    {
        public static IServiceCollection RegisterAuthLogic(this IServiceCollection services)
        {
            services.AddTransient<IAuthManager, AuthManager>();
            return services;
        }
    }
}
