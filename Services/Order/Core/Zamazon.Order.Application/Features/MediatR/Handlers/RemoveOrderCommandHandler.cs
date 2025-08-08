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
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId);
            
            await _repository.DeleteAsync(order);

        }
    }
}
