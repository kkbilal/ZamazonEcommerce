using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamazon.Order.Application.Features.MediatR.Commands
{
    public class RemoveOrderCommand : IRequest
    {
        public int OrderId { get; set; }
        public RemoveOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
