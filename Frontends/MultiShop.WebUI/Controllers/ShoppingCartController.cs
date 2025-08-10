using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async  Task<IActionResult> Index(string code,int discountRate, decimal totalPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Alışveriş";
            ViewBag.directory3 = "Sepetim";
            var values = await _basketService.GetBasketTotal();
            ViewBag.total = values.TotalPrice;
            var totalPrice = values.TotalPrice + values.TotalPrice / 10;
            ViewBag.Tax = values.TotalPrice / 10;
            ViewBag.totalPriceWithTax = totalPrice;
            ViewBag.totalPriceWithDiscount = totalPriceWithDiscount;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            var result = await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
