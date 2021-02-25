using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        private readonly List<DomainEvent> _uncommittedEvents = new List<DomainEvent>();
        protected AggregateRoot() { }
        protected AggregateRoot(TKey id) : base(id)
        {
        }
        public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();
        public void ClearUncommittedEvents()
        {
            this._uncommittedEvents.Clear();
        }
        protected void Publish<T>(T domainEvent) where T : DomainEvent
        {
            this._uncommittedEvents.Add(domainEvent);
        }
    }
}