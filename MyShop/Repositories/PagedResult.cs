using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repositories
{
    public class PagedResult<TData> where TData : class
    {
        public List<TData>? Items { get; init;  }
        public PagingMetadata Pagination { get; init; } = new PagingMetadata();
    }

    public class PagingMetadata
    {
        public int TotalItems { get; set; } = 0;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
