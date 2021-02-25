using System.Collections.Generic;
using Framework.Domain;

namespace ValueObjectIdentifier.Model
{
    public class AccountId : ValueObject<AccountId>
    {
        public long Id { get; set; }
        public AccountId(long id)
        {
            this.Id = id;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.Id;
        }
    }
}