using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Entities.BasketAggregate
{
    public class BasketItem:BaseAuditableEntity
    {
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }
        public int BasketId { get; private set; }
        public BasketItem() { }
        public BasketItem(int catalogItemId, int quantity, decimal unitPrice)
        {
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }
        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity += quantity;
        }
        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;
        }
    }
}
