using System;
using Framework.Domain;

namespace SingleEntity.Model
{
    public class Passport : Entity<long>
    {
        public DateTime ExpireDate { get; private set; }
        public string Number { get; private set; }
        public string Country { get; private set; }
        protected Passport() { }
        public Passport(long id, DateTime expireDate, string number, string country) : base(id)
        {
            ExpireDate = expireDate;
            Number = number;
            Country = country;
        }
    }
}