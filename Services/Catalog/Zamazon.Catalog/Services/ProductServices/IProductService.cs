using Zamazon.Catalog.Dtos.ProductDtos;

namespace Zamazon.Catalog.Services.ProductDetailServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<GetByIdProductDto> GetProductByIdAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);

		Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
    }
}
