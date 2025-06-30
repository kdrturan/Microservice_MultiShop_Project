using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketTotal(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
    }
}
