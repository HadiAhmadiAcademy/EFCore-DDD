using System.Collections.Generic;
using Framework.Domain;

namespace SingleValueObject.Model
{
    public class Name : ValueObject<Name>
    {
        public string Firstname { get; private set; }
        public string Lastname { get;  private set; }
        public Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.Firstname;
            yield return this.Lastname;
        }
    }
}