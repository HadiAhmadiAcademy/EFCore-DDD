using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionOfEntities.Model;
using CollectionOfEntities.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CollectionOfEntities
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new LoanApplicationsDbContext())
            {
                var steps = new List<Step>()
                {
                    new Step(1, "Step-1", OrganizationLevel.FinancingClerk, true),
                    new Step(2, "Step-2", OrganizationLevel.Director, true),
                };
                var decisionHierarchy = new DecisionHierarchy(1, LoanTypes.PersonalLoans, steps);

                await dbContext.DecisionHierarchies.AddAsync(decisionHierarchy);
                await dbContext.SaveChangesAsync();
            }

            using (var readContext = new LoanApplicationsDbContext())
            {
                var hierarchy = readContext.DecisionHierarchies.Include(a=> a.Steps).First();
                var steps = new List<Step>()
                {
                    new Step(1, "Step-1", OrganizationLevel.FinancingClerk, true),      //No-Change
                    new Step(2, "Step-2-Modified", OrganizationLevel.Director, true),            //Updated
                    new Step(3, "Step-3", OrganizationLevel.Director, true),                //Added
                    new Step(4, "Step-4", OrganizationLevel.Director, true)                 //Added
                };
                hierarchy.UpdateSteps(steps);
                await readContext.SaveChangesAsync();
            }

            Console.ReadLine();
        }
    }
}
