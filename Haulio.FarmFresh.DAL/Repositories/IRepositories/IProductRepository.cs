using Haulio.FarmFresh.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.DAL.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductList(int PageNumber, int PageSize, string SearchString);
        Task<Product> GetProductById(int id);
        Task<int> GetProductCount(string SearchString);
    }
}
