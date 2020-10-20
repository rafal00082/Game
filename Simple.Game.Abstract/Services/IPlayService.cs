using Simple.Game.Contract.Play;
using Simple.Game.Utils.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Game.Abstract.Services
{
    public interface IPlayService
    {
        public Task<List<PlayResponse>> Play(PlayersKindEnum playersKindEnum);
    }
}
