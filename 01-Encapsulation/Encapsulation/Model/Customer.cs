using Framework.Domain;

namespace Encapsulation.Model
{
    public class Customer : AggregateRoot<long>
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        protected Customer() { }
        public Customer(long id, string firstname, string lastname) : base(id)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
    }
}