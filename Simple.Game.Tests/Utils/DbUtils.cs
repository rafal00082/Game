using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Simple.Game.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Game.Tests.Utils
{
    public static class DbUtils
    {
        public static GameDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<GameDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new GameDbContext(options);
            return context;
        }

        public static T AddEntity<T>(GameDbContext context, T entity) where T : class
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public static T[] AddRangeEntity<T>(GameDbContext context, T[] entities) where T : class
        {
            context.AddRange(entities);
            context.SaveChanges();
            return entities;
        }
    }
}
