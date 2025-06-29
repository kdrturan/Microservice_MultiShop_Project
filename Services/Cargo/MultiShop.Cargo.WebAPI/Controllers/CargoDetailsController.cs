using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Dto.Dtos.CargoDetailDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _cargoDetailService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _cargoDetailService.TGetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Create(CreateCargoDetailDto cargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                CargoCompanyId = cargoDetailDto.CargoCompanyId,
                SenderCustomer = cargoDetailDto.SenderCustomer,
                ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
                Barcode = cargoDetailDto.Barcode
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update(UpdateCargoDetailDto cargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                CargoCompanyId = cargoDetailDto.CargoCompanyId,
                SenderCustomer = cargoDetailDto.SenderCustomer,
                ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
                Barcode = cargoDetailDto.Barcode,
                Id = cargoDetailDto.Id
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return NoContent();
        }




        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingCompany = _cargoDetailService.TGetById(id);
            if (existingCompany == null)
            {
                return NotFound();
            }
            _cargoDetailService.TDelete(id);
            return Ok();
        }
    }
}
