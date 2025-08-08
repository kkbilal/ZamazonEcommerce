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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task HandleAsync(UpdateOrderDetailCommand command)
        {
            var orderDetail = await _repository.GetByIdAsync(command.OrderDetailId);
            

            orderDetail.ProductId = command.ProductId;
            orderDetail.ProductName = command.ProductName;
            orderDetail.ProductPrice = command.ProductPrice;
            orderDetail.ProductAmount = command.ProductAmount;
            orderDetail.ProductTotalPrice = command.ProductTotalPrice;
            orderDetail.OrderingId = command.OrderingId;

            await _repository.UpdateAsync(orderDetail);
        }
    }
}
