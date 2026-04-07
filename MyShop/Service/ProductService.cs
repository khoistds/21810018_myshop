using MyShop.Models;
using MyShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Service
{
    public class ProductService
    {
        private readonly IRepo<Product, int>? _productsRepo = Services.Get<IRepo<Product, int>>();

        public ProductService()
        {
            
        }

        public async Task<PagedResult<Product>> GetAllProducts(PagingRequest? info = null)
        {
            if (_productsRepo == null) throw new Exception("Product repository not available.");
            return await _productsRepo.GetAll(info);
        }

        public async Task<Product> AddProductAsync(Product newItem)
        {
            return await _productsRepo!.Insert(newItem);
        }

        internal async Task<Product> UpdateProductAsync(Product editItem)
        {
            return await _productsRepo!.Update(editItem);
        }

        internal bool DeleteProductAsync(int Id)
        {
            return _productsRepo!.Delete(Id);
        }
    }
}
