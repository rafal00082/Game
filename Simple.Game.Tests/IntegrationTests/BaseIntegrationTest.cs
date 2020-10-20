using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Simple.Game.Domain;
using System;
using System.Threading.Tasks;

namespace Simple.Game.Tests.IntegrationTests
{
    public abstract class BaseIntegrationTest : IDisposable
    {
       
        protected BaseIntegrationTest()
        {
                var builder = WebHost.CreateDefaultBuilder()
               .UseStartup<StartUpTest>();

            Server = new TestServer(builder);
            DbContext = Server.Host.Services.GetService<GameDbContext>();
            DbContext.Database.AutoTransactionsEnabled = true;
        }

        protected GameDbContext DbContext { get; }
        private TestServer Server { get; }

        public void Dispose()
        {
            DbContext?.Database.EnsureDeleted();
            DbContext?.Dispose();
            Server?.Dispose();
        }

        protected async Task SeedData<T>(T entity) where T : class
        {
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        protected async Task SeedData<T>(T[] entities) where T : class
        {
            DbContext.AddRange(entities);
            await DbContext.SaveChangesAsync();
        }

        protected T GetRequiredService<T>()
        {
            return Server.Host.Services.GetService<T>();
        }
    }
}
