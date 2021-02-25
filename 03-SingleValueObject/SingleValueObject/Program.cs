using System;
using System.Linq;
using System.Threading.Tasks;
using SingleValueObject.Model;
using SingleValueObject.Persistence;

namespace SingleValueObject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new PartiesDbContext())
            {
                var name = new Name("John","Doe");
                var party = new IndividualParty(1, "0010101010", name);
                await dbContext.IndividualParties.AddAsync(party);
                await dbContext.SaveChangesAsync();
            }

            using (var readContext = new PartiesDbContext())
            {
                var party = readContext.IndividualParties.First();
            }

            Console.ReadLine();
        }
    }
}
