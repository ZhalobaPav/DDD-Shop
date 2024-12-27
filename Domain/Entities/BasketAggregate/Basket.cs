using Domain.Common;

namespace Domain.Entities.BasketAggregate
{
    public class Basket:BaseAuditableEntity,IAggregateRoot
    {
        public string BuyerId { get; private set; }
        private List<BasketItem> _items = new List<BasketItem>();
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();
        public int TotalItems => _items.Sum(i => i.Quantity);
        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }
        public void AddItem(int catalogItemId, float unitPrice, int quantity)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                _items.Add(new BasketItem(catalogItemId, quantity, (decimal)unitPrice));
                return;
            }
            var existingItem = Items.First(i=>i.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }
        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
