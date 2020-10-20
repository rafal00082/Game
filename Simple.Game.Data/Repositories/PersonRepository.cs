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
    public class PersonRepository: IPlayerRepository<PersonEntity>
    {
        private readonly GameDbContext _context;
        
        public PersonRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonEntity>> GetTwoRandom()
        {
            var entityList = await _context.Person.OrderBy(x => Guid.NewGuid()).Take(2).ToListAsync();
            return entityList;
        }

        public async Task Update(PersonEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
