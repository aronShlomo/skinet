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
            var products =  await _repo.GetProductsAsync();
            return Ok(products);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }
        
    }
}