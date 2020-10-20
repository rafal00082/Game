using Microsoft.EntityFrameworkCore;
using Simple.Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Game.Domain
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        { }

        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<StarsShipEntity> StarsShip { get; set; }
    }
}
