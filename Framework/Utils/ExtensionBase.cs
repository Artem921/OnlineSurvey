using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Utils
{
    public abstract class ExtensionBase
    {
        public IConfiguration Configuration { get; set; }
        public abstract void Load(IServiceCollection services);
    }
}
