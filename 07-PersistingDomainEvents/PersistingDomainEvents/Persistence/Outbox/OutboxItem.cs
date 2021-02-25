using System;

namespace PersistingDomainEvents.Persistence.Outbox
{
    public class OutboxItem
    {
        public long Id { get; set; }
        public Guid EventId { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}