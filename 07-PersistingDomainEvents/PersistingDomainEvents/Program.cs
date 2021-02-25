using System;
using System.Threading.Tasks;
using PersistingDomainEvents.Model;
using PersistingDomainEvents.Persistence;

namespace PersistingDomainEvents
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new AuctionDbContext())
            {
                var auction = new Auction(1, 1000, DateTime.Now.AddDays(10), 8917);

                dbContext.Auction.Add(auction);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
