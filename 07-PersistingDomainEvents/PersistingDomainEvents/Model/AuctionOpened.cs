using System;
using Framework.Domain;

namespace PersistingDomainEvents.Model
{
    public class AuctionOpened : DomainEvent
    {
        public long Id { get; private set; }
        public long StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long ProductId { get; private set; }

        public AuctionOpened(long id, long startingPrice, DateTime endDateTime, long productId)
        {
            Id = id;
            StartingPrice = startingPrice;
            EndDateTime = endDateTime;
            ProductId = productId;
        }
    }
}