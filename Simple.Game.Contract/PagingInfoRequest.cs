namespace Simple.Game.Contract
{
    public class PagingInfoRequest
    {
        public int PageSize { get; set; }
        public int PageNumber {get; set;}
        public string SortBy { get; set; }
        public string Order { get; set; }
    }
}
