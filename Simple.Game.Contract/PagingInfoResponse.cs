namespace Simple.Game.Contract
{
    public class PagingInfoResponse
    {
        public long PageSize { get; set; }
        public long PageNumber { get; set; }
        public long TotalPagesNumber { get; set; }
        public long TotalResultNumber { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public PagingInfoResponse(long pageSize, long pageNumber, long totalResultNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPagesNumber = totalResultNumber/ pageSize;
            TotalResultNumber = totalResultNumber;
            HasPreviousPage = pageNumber > 1;
            HasNextPage = totalResultNumber > pageSize * pageNumber;
        }
    }
}
