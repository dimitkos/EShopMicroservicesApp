using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        public OrderRepository(OrderContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByUsername(string username)
        {
            var orders = await _context.Orders
                .Where(order => order.UserName == username)
                .ToListAsync();

            return orders;
        }
    }
}
