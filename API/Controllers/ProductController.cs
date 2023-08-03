using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly iProductRepository _repo;



        public ProductController(iProductRepository repo)
        {
                _repo = repo;
        } 




        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
             return  Ok(await _repo.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getProductBrands()
        {
            return Ok(await _repo.GetProductBrandAsync());
        }

          [HttpGet("types")]
          public async Task<ActionResult<IReadOnlyList<ProductType>>> getProductTypes()
        {
            return Ok(await _repo.GetProductsTypeAsync());
        }

        
    }
}