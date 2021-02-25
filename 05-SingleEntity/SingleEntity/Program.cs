using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SingleEntity.Model;
using SingleEntity.Persistence;

namespace SingleEntity
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new TourismDbContext())
            {
                var passport = new Passport(1, DateTime.Now.AddYears(10), "20193-123", "USA");
                var passenger = new Passenger(1, "John", "Doe", passport);

                dbContext.Passengers.Add(passenger);
                await dbContext.SaveChangesAsync();
            }

            using (var readContext = new TourismDbContext())
            {
                var passenger = readContext.Passengers.Include(a=> a.Passport).First();
            }

            Console.ReadLine();
        }
    }
}
