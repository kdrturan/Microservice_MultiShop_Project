using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Command.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailsQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailsByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailsCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailsCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailsCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailsQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailsByIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailsCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailsCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailsCommandHandler)
        {
            _getOrderDetailsQueryHandler = getOrderDetailsQueryHandler;
            _getOrderDetailsByIdQueryHandler = getOrderDetailsByIdQueryHandler;
            _createOrderDetailsCommandHandler = createOrderDetailsCommandHandler;
            _updateOrderDetailsCommandHandler = updateOrderDetailsCommandHandler;
            _removeOrderDetailsCommandHandler = removeOrderDetailsCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailsList()
        {
            var orderDetails = await _getOrderDetailsQueryHandler.Handle();
            if (orderDetails == null || !orderDetails.Any())
            {
                return NotFound("Sipariş detayı bulunamadı");
            }
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailsById(int id)
        {
            var orderDetail = await _getOrderDetailsByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            if (orderDetail == null)
            {
                return NotFound("Sipariş detayı bulunamadı");
            }
            return Ok(orderDetail);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailsCommandHandler.Handle(command);
            return Ok("Sipariş detayı  eklendi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailsCommandHandler.Handle(command);
            return Ok("Sipariş detayı  güncellendi");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailsCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş detayı  silindi");
        }
    }
}