using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionOfValueObjects.Model;
using CollectionOfValueObjects.Persistence;

namespace CollectionOfValueObjects
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new ShopDbContext())
            {
                var order = new Order(1, 100, DateTime.Now);
                var lines = new List<OrderLine>()
                {
                    new OrderLine(2000, 1, 1000),
                    new OrderLine(3000, 2, 50)
                };
                order.AssignLines(lines);

                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();
            }

            using (var readContext = new ShopDbContext())
            {
                var order = readContext.Orders.First();
                var lines = new List<OrderLine>()
                {
                    new OrderLine(2000, 1, 1000),
                    new OrderLine(9000, 9000, 9000),
                };
                order.AssignLines(lines);
                await readContext.SaveChangesAsync();
            }

            Console.ReadLine();
        }
    }
}
