using Simple.Game.Utils.Enums;

namespace Simple.Game.Abstract.Services
{
    public interface IPlayersServiceFactory
    {
        public IPlayerService GetPlayers(PlayersKindEnum playersKindEnum);
    }
}
