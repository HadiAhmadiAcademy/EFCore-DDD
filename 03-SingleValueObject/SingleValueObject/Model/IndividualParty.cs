using Framework.Domain;

namespace SingleValueObject.Model
{
    public class IndividualParty : AggregateRoot<long>
    {
        public string SocialSecurityNumber { get; private set; }
        public Name Name { get; private set; }
        protected IndividualParty() { }
        public IndividualParty(long id, string socialSecurityNumber, Name name) : base(id)
        {
            SocialSecurityNumber = socialSecurityNumber;
            Name = name;
        }
    }
}