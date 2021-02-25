using System;
using Framework.Domain;

namespace PersistingDomainEvents.Model
{
    public class Auction : AggregateRoot<long>
    {
        public long StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long ProductId { get; private set; }
        protected Auction() { }
        public Auction(long id, long startingPrice, DateTime endDateTime, long productId) : base(id)
        {
            StartingPrice = startingPrice;
            EndDateTime = endDateTime;
            ProductId = productId;

            Publish(new AuctionOpened(Id, startingPrice, endDateTime, productId));
        }
    }
}