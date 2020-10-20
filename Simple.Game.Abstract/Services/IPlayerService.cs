using Simple.Game.Contract.Play;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Game.Abstract.Services
{
    public interface IPlayerService
    {
        public Task<List<PlayResponse>> Play();
    }
}
