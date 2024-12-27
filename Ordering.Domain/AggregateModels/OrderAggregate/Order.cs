using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.AggregateModels.OrderAggregate
{
    public class Order: BaseAuditableEntity
    {
        public DateTime OrderDate { get; private set; }
        [Required]
        public Address Address { get; private set; }

        public int? BuyerId { get; private set; }
    }
}
