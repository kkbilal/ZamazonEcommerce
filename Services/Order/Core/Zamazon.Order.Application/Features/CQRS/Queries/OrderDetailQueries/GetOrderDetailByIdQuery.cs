﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Order.Domain.Entities;

namespace Zamazon.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public int OrderDetailId { get; set; }

        public GetOrderDetailByIdQuery(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
