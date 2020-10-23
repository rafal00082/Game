using Simple.Game.Contract.SelectItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Game.Abstract.Services
{
    public interface ISelectItemService
    {
        public Task<IEnumerable<SelectItem>> GetPlayersKindEnumAsSelectItems();
    }
}
