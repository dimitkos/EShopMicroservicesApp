using Ordering.Core.Entities;
using Ordering.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        //here can add custom methods
        Task<IEnumerable<Order>> GetOrdersByUsername(string username);
    }
}
