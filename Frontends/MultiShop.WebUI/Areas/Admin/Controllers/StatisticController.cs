using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticService.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticService.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticService.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _catalogStatisticService.GetBrandCount();
            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            var productCount = await _catalogStatisticService.GetProductCount();
            var maxProductName = await _catalogStatisticService.GetMaxPriceProductNameAsync();
            var minProductName = await _catalogStatisticService.GetMinPriceProductNameAsync();
            var productPriceAvg = await _catalogStatisticService.GetProductAvgPrice();
            var userCount = await _userStatisticService.GetUserCount();
            var commentCount = await _commentStatisticService.GetCommentCountAsync();

            ViewBag.brandCount = brandCount;
            ViewBag.categoryCount = categoryCount;
            ViewBag.productCount = productCount;
            ViewBag.maxProductName = maxProductName;
            ViewBag.minProductName = minProductName;
            ViewBag.productPriceAvg = productPriceAvg;
            ViewBag.userCount = userCount;
            ViewBag.commentCount = commentCount;

            return View();
        }
    }
}
