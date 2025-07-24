using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountsDto);
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountsDto);
        Task DeleteOfferDiscountAsync(string id);
    }
}
