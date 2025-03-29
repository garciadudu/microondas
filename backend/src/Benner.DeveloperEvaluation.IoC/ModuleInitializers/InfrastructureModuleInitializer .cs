using Benner.DeveloperEvaluation.Domain.Repositories;
using Benner.DeveloperEvaluation.ORM;
using Benner.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Benner.DeveloperEvaluation.IoC.ModuleInitializers
{
    public class InfrastructureModuleInitializer: IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
            builder.Services.AddScoped<IProgramaMicroondaRepository, ProgramaMicroondaRepository>();
        }
    }
}
