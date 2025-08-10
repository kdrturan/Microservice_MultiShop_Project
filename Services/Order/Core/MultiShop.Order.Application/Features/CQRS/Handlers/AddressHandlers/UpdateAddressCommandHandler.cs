using MultiShop.Order.Application.Features.CQRS.Command.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AddressId);
            if (value != null)
            {
                value.City = command.CityId;
                value.Detail1 = command.Detail;
                value.District = command.DistrictId;
                value.UserId = command.UserId;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception("Address not found");
            }
        }
    }
}
