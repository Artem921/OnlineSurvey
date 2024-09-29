using Mapster;
using System.Reflection;

namespace OnlineSurvey.Api.Mapping
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;

            Assembly assembly = Assembly.GetExecutingAssembly();
            config.Scan(assembly);

            return services;
        }
    }
}
