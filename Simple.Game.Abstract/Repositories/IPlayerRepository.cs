using Simple.Game.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Game.Abstract.Repositories
{
    public interface IPlayerRepository<T> where T: BaseEntity
    {
        public Task<List<T>> GetTwoRandom();
        public Task Update(T entity);
    }
}
