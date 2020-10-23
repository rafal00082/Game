using Simple.Game.Contract;
using Simple.Game.Contract.Person;
using System.Threading.Tasks;

namespace Simple.Game.Abstract.Services
{
    public interface IPersonService: IPlayerService
    {
        public Task<PagingListResponse<PersonResponse>> Get(int pageNumber, int pageSize, string sortBy, string order);
        public Task<PagingListResponse<PersonResponse>> Get(PagingInfoRequest pagingInfo);
    }
}
