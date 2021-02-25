using System.Collections.Generic;
using System.Linq;
using Framework.Domain;
using Newtonsoft.Json;

namespace PersistingDomainEvents.Persistence.Outbox
{
    public static class OutboxItemFactory
    {
        public static List<OutboxItem> CreateOutboxItemsFromAggregateRoots(List<IAggregateRoot> aggregateRoots)
        {
            return aggregateRoots.SelectMany(a => a.GetUncommittedEvents())
                .Select(MapToOutboxItem)
                .ToList();
        }

        private static OutboxItem MapToOutboxItem(DomainEvent @event)
        {
            return new OutboxItem()
            {
                EventId = @event.EventId,
                Type = @event.GetType().Name,
                PublishDateTime = @event.PublishDateTime,
                Body = JsonConvert.SerializeObject(@event),
            };
        }
    }
}