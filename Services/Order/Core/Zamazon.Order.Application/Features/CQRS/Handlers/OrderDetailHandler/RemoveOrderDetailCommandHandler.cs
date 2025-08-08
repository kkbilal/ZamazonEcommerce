using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Zamazon.Order.Application.Interfaces;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.CQRS.Handlers.OrderDetailHandler
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task HandleAsync(RemoveOrderDetailCommand command)
        {
            var orderDetail = await _repository.GetByIdAsync(command.OrderDetailId);
            

            await _repository.DeleteAsync(orderDetail);
        }
    }
}
