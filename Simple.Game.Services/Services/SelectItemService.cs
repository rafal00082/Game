using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simple.Game.Abstract.Services;
using Simple.Game.Contract.SelectItem;
using Simple.Game.Utils.Enums;
using Simple.Game.Utils.Extensions;

namespace Simple.Game.Services.Services
{

    public class SelectItemService: ISelectItemService
    {
        public SelectItemService()
        { 
        }

        public async Task<IEnumerable<SelectItem>> GetPlayersKindEnumAsSelectItems()
        {
            var list = new List<SelectItem>();

            foreach (PlayersKindEnum enumItem in Enum.GetValues(typeof(PlayersKindEnum)))
            {
                var selectItem = new SelectItem
                {
                    Id = (int)enumItem,
                    Name = enumItem.GetDisplayName()
                };

                list.Add(selectItem);
            }

            return await Task.FromResult(list);
        }
    }

}