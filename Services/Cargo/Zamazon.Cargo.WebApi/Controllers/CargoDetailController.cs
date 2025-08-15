using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Cargo.Business.Abstract;
using Zamazon.Cargo.Dto.Dtos.CargoDetailDtos;
using Zamazon.Cargo.Entity.Concrete;

namespace Zamazon.Cargo.WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet("{cargoId}")]

        public IActionResult GetCargoDetail(int cargoId)
        {
            var cargoDetail = _cargoDetailService.TGetById(cargoId);
            
            return Ok(cargoDetail);
        }
        [HttpGet]
        public IActionResult GetAllCargoDetails()
        {
            var cargoDetails = _cargoDetailService.TGetAll();
            
            return Ok(cargoDetails);
        }
        [HttpPost]
        public IActionResult AddCargoDetail([FromBody] CreateCargoDetailDto createCargoDetailDto)
        {
           CargoDetail cargoDetail = new CargoDetail
           {
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                RecieverCustomer = createCargoDetailDto.RecieverCustomer,
                Barcode = createCargoDetailDto.Barcode

            };

            _cargoDetailService.TAdd(cargoDetail);
            return Ok("Cargo Detail Created Successfully.");
        }
        [HttpPut]

        public IActionResult UpdateCargoDetail([FromBody] UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                RecieverCustomer = updateCargoDetailDto.RecieverCustomer,
                Barcode = updateCargoDetailDto.Barcode
            };

            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Cargo Detail Updated Successfully.");
        }
        [HttpDelete("{cargoId}")]
        public IActionResult DeleteCargoDetail(int cargoId)
        {          
            _cargoDetailService.TDelete(cargoId);
            return Ok("Cargo Detail Deleted Successfully.");
        }
    }
}
