using AutoMapper;
using MongoDB.Driver;
using Zamazon.Catalog.Dtos.SpecialOfferDtos;
using Zamazon.Catalog.Entities;
using Zamazon.Catalog.Settings;

namespace Zamazon.Catalog.Services.SpecialOfferServices
{
	public class SpecialOfferService : ISpecialOfferService
	{
		private readonly IMongoCollection<SpecialOffer> _offerCollection;
		private readonly IMapper _mapper;

		public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_offerCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
			_mapper = mapper;
		}

		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var specialoffer = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
			await _offerCollection.InsertOneAsync(specialoffer);
		}

		public async Task DeleteSpecialOfferAsync(string id)
		{
			await _offerCollection.DeleteOneAsync(c => c.SpecialOfferID == id);
		}

		public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
		{
			var offers = await _offerCollection.Find(c => true).ToListAsync();
			return _mapper.Map<List<ResultSpecialOfferDto>>(offers);
		}

		public async Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
		{
			var value = await  _offerCollection.Find(c => c.SpecialOfferID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdSpecialOfferDto>(value);
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var offer = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
			await _offerCollection.ReplaceOneAsync(c => c.SpecialOfferID == updateSpecialOfferDto.SpecialOfferID, offer);
		}
	}
}
