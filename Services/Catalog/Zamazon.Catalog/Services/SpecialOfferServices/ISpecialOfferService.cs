using Zamazon.Catalog.Dtos.SpecialOfferDtos;

namespace Zamazon.Catalog.Services.SpecialOfferServices
{
	public interface ISpecialOfferService 
	{
		Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
		Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
		Task DeleteSpecialOfferAsync(string id);
	}
}
