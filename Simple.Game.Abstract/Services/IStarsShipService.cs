using Simple.Game.Contract;
using Simple.Game.Contract.StarsShip;
using System.Threading.Tasks;

namespace Simple.Game.Abstract.Services
{
    public interface IStarsShipService:IPlayerService
    {
        public Task<PagingListResponse<StarsShipResponse>> Get(int pageNumber, int pageSize, string sortBy, string order);
    }
}
