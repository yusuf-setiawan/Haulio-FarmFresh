using Haulio.FarmFresh.DTO.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.BusinessLogic.Services
{
    public interface IProductService
    {
        Task<ProductToPageDTO> GetProducts(int PageNumber, int PageSize, string SearchString); 
        Task<ProductToListDTO> AddProduct(ProductToAddDTO productToAddDTO);
        Task<ProductToAddDTO> GetProductById(int Id);
    }
}
