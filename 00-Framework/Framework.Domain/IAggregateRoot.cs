using System.Collections.Generic;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        IReadOnlyList<DomainEvent> GetUncommittedEvents();
        void ClearUncommittedEvents();
    }
}