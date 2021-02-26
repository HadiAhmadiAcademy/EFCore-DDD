using System;
using System.Linq;
using System.Threading.Tasks;
using StatePattern.Model;
using StatePattern.Persistence;

namespace StatePattern
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new SalesDbContext())
            {
                var order = new Order(1, 1000, DateTime.Now);
                order.Confirm();

                dbContext.Orders.Add(order);
                await dbContext.SaveChangesAsync();
            }

            using (var readContext = new SalesDbContext())
            {
                var order = readContext.Orders.First();
            }

            Console.ReadLine();
        }
    }
}
