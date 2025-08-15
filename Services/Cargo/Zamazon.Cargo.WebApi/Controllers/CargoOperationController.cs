using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Cargo.Business.Abstract;
using Zamazon.Cargo.Dto.Dtos.CargoOperationDtos;
using Zamazon.Cargo.Entity.Concrete;

namespace Zamazon.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _cargoOperationService.TGetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _cargoOperationService.TGetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCargoOperationDto CreatecargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = CreatecargoOperationDto.Barcode,
                Description = CreatecargoOperationDto.Description,
                OperationDate = DateTime.Now

            };
            _cargoOperationService.TAdd(cargoOperation);
            return Ok("Cargo Operation Created Successfully.");
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = DateTime.Now
            };

            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Cargo Operation Updated Successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            _cargoOperationService.TDelete(id);
            return Ok("Cargo Operation Deleted Successfully.");
        }
    }
}
