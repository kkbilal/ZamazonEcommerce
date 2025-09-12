using AutoMapper;
using MongoDB.Driver;
using Zamazon.Catalog.Dtos.ProductDtos;
using Zamazon.Catalog.Entities;
using Zamazon.Catalog.Settings;

namespace Zamazon.Catalog.Services.ProductDetailServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
			_categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

		}

        
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(product => product.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
           var products = await _productCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetProductByIdAsync(string id)
        {
            var value = await _productCollection.Find(product => product.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

		public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
		{
			var values = await _productCollection.Find(x=>true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
		}

		public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productCollection.ReplaceOneAsync( p => p.ProductId == updateProductDto.ProductId ,product);
        }
    }
}
