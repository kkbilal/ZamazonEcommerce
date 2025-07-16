using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Catalog.Dtos.ProductDetailDtos;
using Zamazon.Catalog.Dtos.ProductDtos;
using Zamazon.Catalog.Services.ProductDetailServices;
using Zamazon.Catalog.Services.ProductServices;

namespace Zamazon.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        {
            var productDetails = await _productDetailService.GetAllProductDetailAsync();
            return Ok(productDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var productDetail = await _productDetailService.GetProductDetailByIdAsync(id);
            if (productDetail == null)
            {
                return NotFound("ProductDetail not found");
            }
            return Ok(productDetail);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            if (createProductDetailDto == null)
            {
                return BadRequest("Invalid productDetail data");
            }

            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail Added Successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {

            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var product = await _productDetailService.GetProductDetailByIdAsync(id);
            if (product == null)
            {
                return NotFound("ProductDetail not found");
            }

            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail Deleted Successfully");
        }
    }
}
