using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Zamazon.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Zamazon.Order.Application.Interfaces;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.CQRS.Handlers.OrderDetailHandler
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> HandleAsync(GetOrderDetailByIdQuery query)
        {
            

            var orderDetail = await _repository.GetByIdAsync(query.OrderDetailId);
           

            return new GetOrderDetailByIdQueryResult 
            {
                
               ProductAmount = orderDetail.ProductAmount,
               ProductId = orderDetail.ProductId,
               ProductName = orderDetail.ProductName,
               ProductPrice = orderDetail.ProductPrice,
               OrderingId = orderDetail.OrderingId,
               ProductTotalPrice = orderDetail.ProductTotalPrice,
               OrderDetailId = orderDetail.OrderDetailId,
            };
        }
    }
}
