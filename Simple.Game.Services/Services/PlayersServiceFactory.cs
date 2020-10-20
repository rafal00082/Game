using Simple.Game.Abstract.Services;
using Simple.Game.Utils.Enums;

namespace Simple.Game.Services.Services
{
    public class PlayersServiceFactory: IPlayersServiceFactory
    {
        private readonly IPersonService _personService;
        private readonly IStarsShipService _starsShipService;

        public PlayersServiceFactory(IPersonService personService, IStarsShipService starsShipService )
        {
            _personService = personService;
            _starsShipService = starsShipService;
        }

       public IPlayerService GetPlayers(PlayersKindEnum playersKindEnum)
       {
            switch (playersKindEnum)
            {
                case PlayersKindEnum.People: return _personService;
                case PlayersKindEnum.StarsShips: return _starsShipService;
                default: return _personService;
            }
       }
    }
}
