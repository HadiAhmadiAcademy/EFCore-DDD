using Framework.Domain;

namespace ValueObjectIdentifier.Model
{
    public class Account : AggregateRoot<AccountId>
    {
        public string Code { get; private set; }
        protected Account() { }
        public Account(AccountId id, string code) : base(id)
        {
            this.Code = code;
        }
    }
}