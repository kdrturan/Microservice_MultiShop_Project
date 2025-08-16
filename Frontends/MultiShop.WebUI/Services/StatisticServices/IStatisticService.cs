namespace MultiShop.WebUI.Services.StatisticServices
{
    public interface IStatisticService
    {
        int GetCategoryCount();
        int GetProductCount();
        int GetBrandCount();
        decimal GetProductAvgPrice();
    }
}
