using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressServices
    {
        //Task<List<ResultAboutDto>> GetAllAboutAsync();
        //Task<UpdateAboutDto> GetByIdAboutAsync(string id);
        //Task UpdateAboutAsync(UpdateAboutDto updateAboutsDto);
        Task CreateAboutAsync(CreateOrderAddressDto createAboutsDto);
        //Task DeleteAboutAsync(string id);
    }
}
