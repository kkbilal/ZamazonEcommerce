using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Catalog.Dtos.ProductDtos;
using Zamazon.Catalog.Dtos.ProductImageDtos;
using Zamazon.Catalog.Entities;
using Zamazon.Catalog.Services.ProductDetailServices;
using Zamazon.Catalog.Services.ProductImageServices;


namespace Zamazon.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductImages()
        {
            var productImages = await _productImageService.GetAllProductImageAsync();
            return Ok(productImages);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var productImage = await _productImageService.GetProductImageByIdAsync(id);
            if (productImage == null)
            {
                return NotFound("ProductImage not found");
            }
            return Ok(productImage);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            if (createProductImageDto == null)
            {
                return BadRequest("Invalid productImage data");
            }

            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage Added Successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {

            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("ProductImage Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var productImage = await _productImageService.GetProductImageByIdAsync(id);
            if (productImage == null)
            {
                return NotFound("ProductImage not found");
            }

            await _productImageService.DeleteProductImageAsync(id);
            return Ok("ProductImage Deleted Successfully");
        }
    }
}
