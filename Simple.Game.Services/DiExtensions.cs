using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Simple.Game.Abstract.Services;
using Simple.Game.Services.AutoMapper;
using Simple.Game.Services.Services;

namespace Simple.Game.Services
{
    public static class DiExtensions
    {
        public static void AddServicesDi(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton(typeof(IBussinesComparer<>), typeof(BussinesComparer<>));

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IStarsShipService, StarsShipService>();

            
            services.AddScoped<IPlayersServiceFactory, PlayersServiceFactory>();
            services.AddScoped<IPlayService, PlayService>();

        }
    }
}
