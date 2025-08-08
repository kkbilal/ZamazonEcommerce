using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.MediatR.Queries;
using Zamazon.Order.Application.Features.MediatR.Results;
using Zamazon.Order.Application.Interfaces;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.MediatR.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderId);
            return new GetOrderByIdQueryResult
            {
                OrderDate = value.OrderDate,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId,
                OrderingId = value.OrderingId,
            };
        }
    }
}
