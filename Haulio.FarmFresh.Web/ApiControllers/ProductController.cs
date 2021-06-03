using Haulio.FarmFresh.BusinessLogic;
using Haulio.FarmFresh.BusinessLogic.Services;
using Haulio.FarmFresh.DTO.DTOs;
using Haulio.FarmFresh.DTO.Model;
using Haulio.FarmFresh.DTO.Wrappers;
using Haulio.FarmFresh.Utility;
using Haulio.FarmFresh.Web.Helper;
using Haulio.FarmFresh.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.Web.Controllers.Controllers
{
    [FarmFreshAuthorization]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedProduct = await _productService.GetProducts(filter.PageNumber, filter.PageSize, filter.Search);
            var pagedData = pagedProduct.Products;
            var totalRecords = pagedProduct.count;

            var pagedReponse = PaginationHelper.CreatePagedReponse<ProductToListDTO>(pagedData, validFilter, totalRecords);
            return Ok(pagedReponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await _productService.GetProductById(id.ParseInt());

            var response = new Response<ProductToAddDTO>(product);
             
            return Ok(response);
        }

        [HttpPost("Cart")]
        public IActionResult AddToCart([FromBody]CartModel product)
        {
            var Cart = HttpContext.Session.GetString("Cart");

            List<CartModel> list = Cart == null ? new List<CartModel>() : JsonConvert.DeserializeObject<List<CartModel>>(Cart);

            list.Add(product);
            string listStr = JsonConvert.SerializeObject(list);
            HttpContext.Session.SetString("Cart", listStr);
            HttpContext.Session.SetString("CartCount", list.Count.ToString());

            return Ok(true);
        }
    }
}
