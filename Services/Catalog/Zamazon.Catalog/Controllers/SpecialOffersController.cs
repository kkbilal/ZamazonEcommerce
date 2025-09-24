using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Catalog.Dtos.SpecialOfferDtos;
using Zamazon.Catalog.Services.SpecialOfferServices;

namespace Zamazon.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class SpecialOffersController : ControllerBase
	{
		private readonly ISpecialOfferService _specialofferService;

		public SpecialOffersController(ISpecialOfferService SpecialOfferService)
		{
			_specialofferService = SpecialOfferService;
		}
		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var offers = await _specialofferService.GetAllSpecialOfferAsync();
			return Ok(offers);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSpecialOfferById(string id)
		{
			var offers = await _specialofferService.GetSpecialOfferByIdAsync(id);
			return Ok(offers);
		}
		[HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{

			await _specialofferService.CreateSpecialOfferAsync(createSpecialOfferDto);
			return Ok("SpecialOffer Added Successfully");

		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
		{

			await _specialofferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
			return Ok("SpecialOffer Updated Successfully");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			await _specialofferService.DeleteSpecialOfferAsync(id);
			return Ok("SpecialOffer Deleted Successfully");
		}
	}
}
