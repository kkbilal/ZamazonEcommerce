using AutoMapper;
using MongoDB.Driver;
using Zamazon.Catalog.Dtos.ProductDetailDtos;
using Zamazon.Catalog.Entities;
using Zamazon.Catalog.Settings;

namespace Zamazon.Catalog.Services.ProductServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailsCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailsCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var reatedProductDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailsCollection.InsertOneAsync(reatedProductDetail);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailsCollection.DeleteOneAsync(detail => detail.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var products = await _productDetailsCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(products);
        }

        public async Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string id)
        {
            var productDetail = await _productDetailsCollection.Find(detail => detail.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailsCollection.ReplaceOneAsync(
                               detail => detail.ProductDetailId == updateProductDetailDto.ProductDetailId, 
                                              productDetail);
        }
    }
}
