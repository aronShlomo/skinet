using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specification;
using API.Dtos;
using AutoMapper;
using API.Controllers;
using API.Errors;

namespace Infrastructure.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo, 
        IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        } 



        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDtos>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiDataResponse(404));
            
            return _mapper.Map<Product, ProductToReturnDtos>(product);

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDtos>>> GetProducts()
        {
               var spec = new ProductWithTypesAndBrandsSpecification();
               var products = await _productRepo.ListAsync(spec);
               return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDtos>>(products));
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.GetListAsync());
        }

          [HttpGet("types")]
          public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.GetListAsync());
        }

        
    }
}