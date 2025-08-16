using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderingOrderService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOrderingService orderingOrderService, IUserService userService)
        {
            _orderingOrderService = orderingOrderService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var userId = await _userService.GetUserInfo();
            var values = await _orderingOrderService.GetOrderingByUserId(userId.Id);
            return View(values);
        }
    }
}
