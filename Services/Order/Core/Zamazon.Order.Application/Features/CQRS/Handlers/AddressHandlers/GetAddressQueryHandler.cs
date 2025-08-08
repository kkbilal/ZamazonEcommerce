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
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> HandleAsync()
        {
            var addresses = await _repository.GetAllAsync();
            return addresses.Select(a => new GetAddressQueryResult
            {
                AddressId = a.AddressId,
                UserId = a.UserId,
                District = a.District,
                City = a.City,
                Detail = a.Detail
            }).ToList();

            
        }
    }
}
