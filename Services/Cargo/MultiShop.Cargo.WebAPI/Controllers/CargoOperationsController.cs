using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoOperationDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
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
        public IActionResult Create(CreateCargoOperationDto cargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description,
                OperationDate = cargoOperationDto.OperationDate
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update(UpdateCargoOperationDto cargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Id = cargoOperationDto.Id,
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description,
                OperationDate = cargoOperationDto.OperationDate
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingCompany = _cargoOperationService.TGetById(id);
            if (existingCompany == null)
            {
                return NotFound();
            }
            _cargoOperationService.TDelete(id);
            return Ok();
        }
    }
}
