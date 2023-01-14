using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cerulean.Server
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(p => p.GetService<TService>);
        }
    }
}
