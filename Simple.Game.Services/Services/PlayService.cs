using Simple.Game.Abstract.Services;
using Simple.Game.Contract;
using Simple.Game.Contract.Play;
using Simple.Game.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Game.Services.Services
{
    public class PlayService: IPlayService
    {
        private readonly PlayersServiceFactory _playersServiceFactory;

        public PlayService(PlayersServiceFactory playersServiceFactory)
        {
            _playersServiceFactory = playersServiceFactory;
        }

        public async Task<List<PlayResponse>> Play(PlayersKindEnum playersKindEnum)
        {
            return await _playersServiceFactory.GetPlayers(playersKindEnum).Play();
        }
    }

    
}
