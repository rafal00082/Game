using Microsoft.EntityFrameworkCore;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Domain;
using Simple.Game.Domain.Entities;
using Simple.Game.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Game.Data.Repositories
{
    public class PersonRepository: IPlayerRepository<PersonEntity>
    {
        private readonly GameDbContext _context;
        private const int maxPageSize = 50;
        private const string descendingOrder = "desc";
        private const string defaultSortProperty = "Id";
         
        public PersonRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonEntity>> Get(int pageNumber, int pageSize, string sortBy, string order)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = (pageSize <= 0 || pageSize > maxPageSize) ? maxPageSize : pageSize;
            sortBy = typeof(PersonEntity).GetProperty(sortBy) != null ? sortBy : defaultSortProperty;
            var isAscending = !descendingOrder.Equals(order.ToLowerInvariant());
            var entitiesList = await _context.Person.OrderByDynamic(sortBy, isAscending).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return entitiesList;
        }

        public async Task<long> GetAmount()
        {
            var amount = await _context.Person.CountAsync();
            return amount;
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
