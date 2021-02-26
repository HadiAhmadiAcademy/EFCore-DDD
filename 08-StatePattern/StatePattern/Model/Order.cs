using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Framework.Domain;

namespace StatePattern.Model
{
    public class Order : AggregateRoot<long>
    {
        public long CustomerId { get; private set; }
        public DateTime IssueDate { get; private set; }
        public OrderState State { get; private set; }
        protected Order() { }
        public Order(long id, long customerId, DateTime issueDate) : base(id)
        {
            CustomerId = customerId;
            IssueDate = issueDate;
            this.State = new DraftState();
        }

        public void Update()
        {
            if (this.State.CanModify())
            {
                //....
            }
        }
        public void Confirm()
        {
            this.State = this.State.Confirm();
        }
        public void Ship()
        {
            this.State = this.State.Ship();
        }
    }
}