using Domain.Common;
using Domain.Entities;

namespace Domain.Events.CatalogItems
{
    public class CatalogItemDeletedEvent:BaseEvent
    {
        public CatalogItem CatalogItem { get; set; }
        public CatalogItemDeletedEvent(CatalogItem catalogItem)
        {
            CatalogItem = catalogItem;
        }
    }
}
