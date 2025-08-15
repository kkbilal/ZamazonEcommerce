using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Cargo.Business.Abstract;
using Zamazon.Cargo.Dto.Dtos.CargoCompanyDtos;
using Zamazon.Cargo.Entity.Concrete;

namespace Zamazon.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _cargoCompanyService.TGetAll();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _cargoCompanyService.TGetById(id);
            
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add([FromBody] CreateCargoCompanyDto createCargoCompanyDto )
        {
            var cargoCompany = new CargoCompany
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TAdd(cargoCompany);          
            return Ok("Cargo Company Successfully Created.");

        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var cargoCompany = new CargoCompany
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Cargo Company Successfully Updated.");
                      
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoCompanyService.TDelete(id);

            return Ok("Cargo Company Successfully Deleted.");
        }
    }
}
