namespace MultiShop.WebUI.Services.StatisticService.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductNameAsync();
        Task<string> GetMinPriceProductNameAsync();
    }
}
