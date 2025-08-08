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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task HandleAsync(CreateOrderDetailCommand command)
        {
            var orderDetail = new OrderDetail
            {
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductAmount = command.ProductAmount,
                ProductTotalPrice = command.ProductTotalPrice,
                OrderingId = command.OrderingId
            };

            await _repository.AddAsync(orderDetail);
        }
    }
}
