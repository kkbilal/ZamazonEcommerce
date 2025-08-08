using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.CQRS.Commands.AddressCommands;
using Zamazon.Order.Application.Interfaces;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task HandleAsync(CreateAddressCommand command)
        {
            var address = new Address
            {
               
               City = command.City,
               Detail = command.Detail,
               District = command.District,
               UserId = command.UserId
            };
            await _repository.AddAsync(address);

            
        }
    }
}
