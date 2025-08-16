using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync();
        Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
    }
}
