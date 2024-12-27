using Domain.Common;
using Domain.Entities;

namespace Domain.Events.CatalogItems
{
    public class CatalogItemUpdatedEvent:BaseEvent
    {
        public CatalogItem CatalogItem { get; set; }
        public CatalogItemUpdatedEvent(CatalogItem catalogItem)
        {
            CatalogItem = catalogItem;
        }
    }
}
