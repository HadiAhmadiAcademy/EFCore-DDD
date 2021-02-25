using System;
using System.Linq;
using System.Threading.Tasks;
using ValueObjectIdentifier.Model;
using ValueObjectIdentifier.Persistence;

namespace ValueObjectIdentifier
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new AccountingDbContext())
            {
                var account = new Account(new AccountId(1), "0010102");
                await dbContext.Accounts.AddAsync(account);
                await dbContext.SaveChangesAsync();
            }

            using (var readContext = new AccountingDbContext())
            {
                var account = readContext.Accounts.First();
            }

            Console.ReadLine();
        }
    }
}
