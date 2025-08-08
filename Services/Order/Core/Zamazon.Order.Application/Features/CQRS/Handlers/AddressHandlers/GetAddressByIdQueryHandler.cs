using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.CQRS.Queries.AddressQueries;
using Zamazon.Order.Application.Features.CQRS.Results.AddressResults;
using Zamazon.Order.Application.Interfaces;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> HandleAsync(GetAddressByIdQuery query)
        {
            

            var address = await _repository.GetByIdAsync(query.AddressId);
            

            return new GetAddressByIdQueryResult
            {
                AddressId = address.AddressId,
                UserId = address.UserId,
                District = address.District,
                City = address.City,
                Detail = address.Detail
            };
        }
    }
}
