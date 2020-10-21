using System.Collections.Generic;

namespace Simple.Game.Contract
{
    public class PagingListResponse<T>
    {
        public PagingInfoResponse PagingInfo { get; set; }
        public List<T> Items { get; set; }
    }
}
