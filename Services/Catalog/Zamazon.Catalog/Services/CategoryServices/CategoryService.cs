using AutoMapper;
using MongoDB.Driver;
using Zamazon.Catalog.Dtos.CategoryDtos;
using Zamazon.Catalog.Entities;
using Zamazon.Catalog.Settings;

namespace Zamazon.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {           
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteCategoryAsync(string id)
        {
           await _categoryCollection.DeleteOneAsync(c => c.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var categories =await _categoryCollection.Find(c => true).ToListAsync();
             return _mapper.Map<List<ResultCategoryDto>>(categories);

        }

        public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id)
        {
            var value = await _categoryCollection.Find(c => c.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.ReplaceOneAsync(c => c.CategoryId == updateCategoryDto.CategoryId, category);
        }
    }
}
