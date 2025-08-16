using MultiShop.DtoLayer.CargoDtos.CargoCustomerDetos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);

    }
}
