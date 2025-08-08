using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Application.Features.MediatR.Results;

namespace Zamazon.Order.Application.Features.MediatR.Queries
{
    public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
    {
    }
}
