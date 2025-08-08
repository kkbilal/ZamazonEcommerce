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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task HandleAsync(UpdateAddressCommand command)
        {
            var address = await _repository.GetByIdAsync(command.AddressId);
           
            address.AddressId = command.AddressId;
            address.District = command.District;
            address.City = command.City;
            address.Detail = command.Detail;
            address.UserId = command.UserId;

            await _repository.UpdateAsync(address);
        }
    }
}
