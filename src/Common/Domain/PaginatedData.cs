using System.Collections.Generic;
using System.Linq;

namespace Wallet.Common.Domain
{
    public class PaginatedData<T> : PaginatedDataBase
    {
        public IEnumerable<T> Data { get; }

        protected PaginatedData()
        {
            Data = Enumerable.Empty<T>();
        }

        protected PaginatedData(IEnumerable<T> items,
                                int page,
                                int pageSize,
                                int totalPages,
                                int totalResults,
                                int recordsFiltered = 0) : base(page, pageSize, totalPages, totalResults, recordsFiltered)
        {
            Data = items;
        }

        public static PaginatedData<T> Create(IEnumerable<T> items,
                                              int page,
                                              int pageSize,
                                              int totalPages,
                                              int totalResults,
                                              int recordsFiltered = 0)
        {
            return new PaginatedData<T>(items, page, pageSize, totalPages, totalResults, recordsFiltered);
        }

        /// <summary>
        /// Convert all data to paginated. No pagination applied.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static PaginatedData<T> Create(IEnumerable<T> items)
        {
            return new PaginatedData<T>(items, 1, items.Count(), 1, items.Count(), items.Count());
        }

        public static PaginatedData<T> From(PaginatedDataBase result, IEnumerable<T> items)
        {
            return new PaginatedData<T>();
            //return new PaginatedData<T>(items, result.Page, result.PageSize, result.TotalPages, result.TotalResults);
        }

        public static PaginatedData<T> Empty => new PaginatedData<T>();
    }
}
