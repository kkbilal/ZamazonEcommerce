using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.MediatR.Commands;
using Zamazon.Order.Application.Interfaces;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.MediatR.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderingId);

            order.UserId = request.UserId;
            order.TotalPrice = request.TotalPrice;
            order.OrderDate = request.OrderDate;

            await _repository.UpdateAsync(order);


        }
    }
}
