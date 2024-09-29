using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Framework.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterModule<T>(this IServiceCollection serviceCollection, IConfiguration configuration)
            where T : ExtensionBase
        {
            var module = Activator.CreateInstance<T>();
            module.Configuration = configuration;
            module.Load(serviceCollection);
        }
    }
}
