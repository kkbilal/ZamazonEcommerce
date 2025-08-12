using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Catalog.Dtos.ProductDtos;
using Zamazon.Catalog.Services.ProductDetailServices;

namespace Zamazon.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProductAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                return BadRequest("Invalid product data");
            }

            await _productService.CreateProductAsync(createProductDto);
            return Ok("Product Added Successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, UpdateProductDto updateProductDto)
        {
                      
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Product Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            await _productService.DeleteProductAsync(id);
            return Ok("Product Deleted Successfully");
        }
    }
}
