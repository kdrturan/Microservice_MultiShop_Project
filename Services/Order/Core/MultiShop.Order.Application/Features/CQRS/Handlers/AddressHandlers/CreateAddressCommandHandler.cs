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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            await _repository.CreateAsync(new Address
            {
                City = command.City,
                Detail1 = command.Detail1,
                Detail2 = command.Detail2,
                District = command.District,
                UserId = command.UserId,
                Country = command.Country,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Description = command.Description,
                ZipCode = command.ZipCode

            });
        }
    }
}
