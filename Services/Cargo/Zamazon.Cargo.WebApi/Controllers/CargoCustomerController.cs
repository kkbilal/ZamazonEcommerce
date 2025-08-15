using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Cargo.Business.Abstract;
using Zamazon.Cargo.Dto.Dtos.CargoCustomerDtos;
using Zamazon.Cargo.Entity.Concrete;

namespace Zamazon.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _cargoCustomerService.TGetAll();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _cargoCustomerService.TGetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCargoCustomerDto createCargoCustomerDto)
        {
           CargoCustomer cargoCustomer = new CargoCustomer
           {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City
            };

            _cargoCustomerService.TAdd(cargoCustomer);
            return Ok("Cargo Customer Created Successfully.");
            
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City
            };

            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Cargo Customer Updated Successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _cargoCustomerService.TDelete(id);
            return Ok("Cargo Customer Deleted Successfully.");
        }

    }
}
