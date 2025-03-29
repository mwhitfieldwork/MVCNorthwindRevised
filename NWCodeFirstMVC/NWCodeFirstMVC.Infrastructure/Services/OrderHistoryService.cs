using Microsoft.EntityFrameworkCore;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.Infrastructure.Services
{
    public class OrderHistoryService : GenericService<OrderDetailsExtended>, IOrderHistory
    {
        private readonly northwindContext _dc;
        public OrderHistoryService(northwindContext dc) : base(dc)
        {
            this._dc = dc;
        }

        public async Task<List<OrderDetailsExtended>> GetOrderHistory()
        {
            return await _dc.OrderDetails
            .Join(_dc.Products,
                  o => o.ProductId,
                  p => p.ProductId,
                  (o, p) => new OrderDetailsExtended
                  {
                      OrderId = o.OrderId,
                      ProductId = p.ProductId,
                      UnitPrice = o.UnitPrice,
                      Discount = o.Discount,
                      ProductName = p.ProductName, // Directly get the ProductName from the join
                      Quantity = o.Quantity
                  })
            .Take(25)
            .ToListAsync();
        }
    }
}
