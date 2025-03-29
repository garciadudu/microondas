using Microsoft.AspNetCore.Builder;

namespace Benner.DeveloperEvaluation.IoC
{
    public interface IModuleInitializer
    {
        void Initialize(WebApplicationBuilder builder);
    }
}
