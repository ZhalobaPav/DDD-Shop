using Domain.Common;
using Domain.Entities;

namespace Domain.Events.CatalogItems
{
    public class CatalogItemCreatedEvent:BaseEvent
    {
        public CatalogItem CatalogItem { get; set; }
        public CatalogItemCreatedEvent(CatalogItem catalogItem)
        {
            CatalogItem = catalogItem;
        }
    }
}
