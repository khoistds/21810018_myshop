using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repositories
{
    public class PagingRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public interface IRepo<TData, TKey> where TData : class
    {
        Task<PagedResult<TData>> GetAll(PagingRequest? info = null);
        Task<TData> Get(TKey id);
        Task<TData> Insert(TData item);
        Task<TData> Update(TData item);
        bool Delete(TKey id);
    }
}
