using System.Collections.Generic;
using Framework.Domain;

namespace CollectionOfValueObjects.BetterPerformance.Model
{
    public class OrderLine : ValueObject<OrderLine>
    {
        public long ProductId { get; private set; }
        public long Quantity { get; private set; }
        public long EachPrice { get; private set; }
        protected OrderLine() { }
        public OrderLine(long productId, long quantity, long eachPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            EachPrice = eachPrice;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.ProductId;
            yield return this.Quantity;
            yield return this.EachPrice;
        }
    }
}