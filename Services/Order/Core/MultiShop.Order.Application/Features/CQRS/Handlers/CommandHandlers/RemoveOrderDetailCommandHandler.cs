using MultiShop.Order.Application.Features.CQRS.Command.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var orderDetail = await _repository.GetByIdAsync(command.Id);
            if (orderDetail != null)
            {
                await _repository.DeleteAsync(orderDetail);
            }
            else
            {
                throw new Exception("Order detail not found");
            }
        }
    }
}
