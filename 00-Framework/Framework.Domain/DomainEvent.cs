using System;
using System.Drawing;

namespace Framework.Domain
{
    public class DomainEvent
    {
        public Guid EventId { get; set; }
        public DateTime PublishDateTime { get; set; }
        public DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.PublishDateTime = DateTime.Now;
        }
    }
}