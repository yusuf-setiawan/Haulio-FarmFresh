using Haulio.FarmFresh.DAL.DataContext;
using Haulio.FarmFresh.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly FarmFreshDbContext _farmFreshDbContext;
        public ProductRepository(FarmFreshDbContext farmFreshDbContext) : base(farmFreshDbContext)
        {
            _farmFreshDbContext = farmFreshDbContext;
        }

        public async Task<List<Product>> GetProductList(int PageNumber, int PageSize, string SearchString)
        {
            if (SearchString == null)
                return await GetProductList(PageNumber, PageSize);

            return await _farmFreshDbContext.Products.Where(x=>x.ProductName.Contains(SearchString)) 
               .Skip((PageNumber - 1) * PageSize)
               .Take(PageSize)
               .ToListAsync();
        }

        private async Task<List<Product>> GetProductList(int PageNumber, int PageSize)
        {
            return await _farmFreshDbContext.Products
               .Skip((PageNumber - 1) * PageSize)
               .Take(PageSize)
               .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _farmFreshDbContext.Products.Where(x=>x.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<int> GetProductCount(string SearchString)
        {
            if (string.IsNullOrEmpty(SearchString))
                return await _farmFreshDbContext.Products.CountAsync();
            else
                return await _farmFreshDbContext.Products.Where(x => x.ProductName.Contains(SearchString)).CountAsync();
        }
    }
}
