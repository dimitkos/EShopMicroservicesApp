using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryAvalaibality = retry.Value;

            try
            {
                context.Database.Migrate();

                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(GetPreconfiguredOrders());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryAvalaibality < 3)
                {
                    retryAvalaibality++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryAvalaibality);
                }

            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order() { UserName = "swn", FirstName = "Dimitris", LastName = "Kosmas", EmailAddress = "dkos@yahoo.com", AddressLine = "Athens", TotalPrice = 5239 },
            };
        }
    }
}
