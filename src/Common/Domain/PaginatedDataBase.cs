namespace Wallet.Common.Domain
{
    public class PaginatedDataBase
    {
        public int RecordsTotal { get; set; }

        public int RecordsFiltered { get; }

        public int Page { get; set; }

        public int Draw { get => Page; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        protected PaginatedDataBase()
        {
        }

        protected PaginatedDataBase(int page, int pageSize, int totalPages, int totalResults, int recordsFiltered = 0)
        {
            Page = page > totalPages ? totalPages : page;
            PageSize = pageSize;
            TotalPages = totalPages;
            RecordsTotal = totalResults;
            RecordsFiltered = recordsFiltered;
        }
    }
}
