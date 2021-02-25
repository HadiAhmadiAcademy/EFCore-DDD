using System;
using System.Collections.Generic;
using Framework.Domain;

namespace CollectionOfValueObjects.Model
{
    public class Order : AggregateRoot<long>
    {
        private List<OrderLine> _orderLines;
        public long CustomerId { get; private set; }
        public DateTime IssueDate { get; private set; }
        public IReadOnlyList<OrderLine> OrderLines => _orderLines.AsReadOnly();
        protected Order() { }
        public Order(long id, long customerId, DateTime issueDate) : base(id)
        {
            CustomerId = customerId;
            IssueDate = issueDate;
            this._orderLines = new List<OrderLine>();
        }

        public void AssignLines(List<OrderLine> orderLines)
        {
            this._orderLines = orderLines;
        }
    }
}