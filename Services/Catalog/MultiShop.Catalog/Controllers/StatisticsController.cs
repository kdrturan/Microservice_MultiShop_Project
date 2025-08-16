using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("category-count")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var values = await _statisticService.GetCategoryCount();
            return Ok(values);
        }

        [HttpGet("product-count")]
        public async Task<IActionResult> GetProductCount()
        {
            var values = await _statisticService.GetProductCount();
            return Ok(values);
        }

        [HttpGet("brand-count")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _statisticService.GetBrandCount();
            return Ok(values);
        }

        [HttpGet("product-avg-price")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var values = await _statisticService.GetProductAvgPrice();
            return Ok(values);
        }

        [HttpGet("max-price-product-name")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var values = await _statisticService.GetMaxPriceProductNameAsync();
            return Ok(values);
        }

        [HttpGet("min-price-product-name")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var values = await _statisticService.GetMinPriceProductNameAsync();
            return Ok(values);
        }
    }
}