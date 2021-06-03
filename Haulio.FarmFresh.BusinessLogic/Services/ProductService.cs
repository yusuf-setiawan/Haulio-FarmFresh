using AutoMapper;
using Haulio.FarmFresh.DAL.Repositories;
using Haulio.FarmFresh.DTO.DTOs;
using Haulio.FarmFresh.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductToListDTO> AddProduct(ProductToAddDTO productToAddDTO)
        {
            return _mapper.Map<ProductToListDTO>(await _productRepository.Add(_mapper.Map<Product>(productToAddDTO)));
        }

        public async Task<ProductToPageDTO> GetProducts(int PageNumber, int PageSize, string SearchString)
        {
            ProductToPageDTO result = new ProductToPageDTO()
            {
                count = await _productRepository.GetProductCount(SearchString),
                Products = _mapper.Map<List<ProductToListDTO>>(await _productRepository.GetProductList(PageNumber, PageSize, SearchString))
            };
            return result;
        } 

        public async Task<ProductToAddDTO> GetProductById(int Id)
        {
            return _mapper.Map<ProductToAddDTO>(await _productRepository.GetProductById(Id));
        }
    }

}
