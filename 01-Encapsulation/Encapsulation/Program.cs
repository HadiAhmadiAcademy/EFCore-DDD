using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encapsulation.Model;
using Encapsulation.Persistence;

namespace Encapsulation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var dbContext = new SalesDbContext())
            {
                var customer = new Customer(1, "John", "Doe");
                await dbContext.Customers.AddAsync(customer);
                await dbContext.SaveChangesAsync();
            }

            using (var readContext = new SalesDbContext())
            {
                var customer = readContext.Customers.First();
            }

            Console.ReadLine();
        }
    }
}
