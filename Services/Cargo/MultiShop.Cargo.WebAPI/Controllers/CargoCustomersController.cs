using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Dto.Dtos.CargoDetailDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
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
        public IActionResult Create(CreateCargoCustomerDto cargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                City = cargoCustomerDto.City,
                District = cargoCustomerDto.District,
                Address = cargoCustomerDto.Address,
                Email = cargoCustomerDto.Email,
                Name = cargoCustomerDto.Name,
                Surname = cargoCustomerDto.Surname,
                PhoneNumber = cargoCustomerDto.PhoneNumber,
                UserCustomerId = cargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update(UpdateCargoCustomerDto cargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                Id = cargoCustomerDto.Id,
                City = cargoCustomerDto.City,
                District = cargoCustomerDto.District,
                Address = cargoCustomerDto.Address,
                Email = cargoCustomerDto.Email,
                Name = cargoCustomerDto.Name,
                Surname = cargoCustomerDto.Surname,
                PhoneNumber = cargoCustomerDto.PhoneNumber
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return NoContent();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingCompany = _cargoCustomerService.TGetById(id);
            if (existingCompany == null)
            {
                return NotFound();
            }
            _cargoCustomerService.TDelete(id);
            return Ok();
        }

        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            var result = _cargoCustomerService.TGetCargoCustomerById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
