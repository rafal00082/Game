using Simple.Game.Abstract.Initialize;
using Simple.Game.Domain;
using Simple.Game.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Game.Data.Initialize
{
    public class DbInicializer : IDbInicializer
    {
        private readonly GameDbContext _context;
        private readonly IRandomProvider _randomProvider;

        public DbInicializer(GameDbContext context, IRandomProvider randomProvider)
        {
            _context = context;
            _randomProvider = randomProvider;
        }

        public async Task SeedInitData()
        {
            if (_context.Person.Count() <= 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    _context.Person.Add (new PersonEntity
                    {
                        Name = $"Person {i}",
                        Mass = GenerateRandomDouble(10.0, 200.0),
                        Wins = GenerateRandomInt(0, 500)
                    });
                }
            }
            if(_context.StarsShip.Count() <= 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    _context.StarsShip.Add(new StarsShipEntity
                    {
                        Name = $"StarsShip {i}",
                        Crew = GenerateRandomInt(1, 20),
                        Wins = GenerateRandomInt(0, 500)
                    });
                }
            }
            await _context.SaveChangesAsync();
        }
        
        private double GenerateRandomDouble(double min, double max)
        {
            return Math.Round(_randomProvider.NextDouble() * (max - min) + min, 2);
        }

        private int GenerateRandomInt(int min, int max)
        {
            return _randomProvider.Next(min, max);
        }
    }
}
