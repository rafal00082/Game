using Microsoft.EntityFrameworkCore;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Domain;
using Simple.Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Game.Data.Repositories
{
    public class StarsShipRepository: IPlayerRepository<StarsShipEntity>
    {
        private readonly GameDbContext _context;

        public StarsShipRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<List<StarsShipEntity>> GetTwoRandom()
        {
            var entityList = await _context.StarsShip.OrderBy(x => Guid.NewGuid()).Take(2).ToListAsync();
            return entityList;
        }

        public async Task Update(StarsShipEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
