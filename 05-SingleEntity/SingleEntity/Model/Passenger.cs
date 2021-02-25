using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace SingleEntity.Model
{
    public class Passenger : AggregateRoot<long>
    {
        public string Firstname { get; private  set; }
        public string Lastname { get; private set; }
        public Passport Passport { get;  set; }
        protected Passenger() { }
        public Passenger(long id, string firstname, string lastname, Passport passport) : base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Passport = passport;
        }
    }
}
