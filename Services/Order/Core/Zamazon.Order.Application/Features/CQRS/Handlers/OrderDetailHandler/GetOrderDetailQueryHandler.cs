using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.CQRS.Results.AddressResults;
using Zamazon.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Zamazon.Order.Application.Interfaces;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.CQRS.Handlers.OrderDetailHandler
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> HandleAsync()
        {
            var orderDetails = await _repository.GetAllAsync();
            return orderDetails.Select(a => new GetOrderDetailQueryResult
            {
                OrderDetailId = a.OrderDetailId,
                ProductTotalPrice = a.ProductTotalPrice,
                ProductName = a.ProductName,
                ProductId = a.ProductId,
                ProductPrice = a.ProductPrice,
                ProductAmount = a.ProductAmount,
                OrderingId = a.OrderingId
                
                
            }).ToList();


        }
    }
}
