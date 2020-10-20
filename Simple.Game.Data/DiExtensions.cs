using Microsoft.Extensions.DependencyInjection;
using Simple.Game.Abstract.Initialize;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Data.Initialize;
using Simple.Game.Data.Repositories;
using Simple.Game.Domain.Entities;

namespace Simple.Game.Data
{
    public static class DiExtensions
    {
        public static void AddRepositoriesDi(this IServiceCollection services)
        {
            services.AddScoped<IRandomProvider, RandomProvider>();
            services.AddScoped<IDbInicializer, DbInicializer>();

            services.AddScoped<IPlayerRepository<PersonEntity>, PersonRepository>();
            services.AddScoped<IPlayerRepository<StarsShipEntity>, StarsShipRepository>();
        }
    }
}
