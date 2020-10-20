using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Game.Data;
using Simple.Game.Domain;
using Simple.Game.Services;
using System;

namespace Simple.Game.Tests.IntegrationTests
{
    public class StartUpTest
    {
        public StartUpTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GameDbContext>(options =>
             options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddRepositoriesDi();
            services.AddServicesDi();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
