using Microsoft.Extensions.DependencyInjection;
using Simple.Game.Abstract.Initialize;
using Simple.Game.Data.Initialize;

namespace Simple.Game.Data
{
    public static class DiExtensions
    {
        public static void AddRepositoriesDi(this IServiceCollection services)
        {
            services.AddScoped<IRandomProvider, RandomProvider>();
            services.AddScoped<IDbInicializer, DbInicializer>();
        }
    }
}
