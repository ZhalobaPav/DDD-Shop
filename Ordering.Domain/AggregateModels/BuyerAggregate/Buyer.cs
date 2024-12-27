using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.AggregateModels.BuyerAggregate
{
    public class Buyer:BaseAuditableEntity, IAggregateRoot
    {
        [Required]
        public string IdentityGuid { get; private set; }

        public string Name { get; private set; }

        private List<PaymentMethod> _paymentMethods;

        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

        protected Buyer()
        {

            _paymentMethods = new List<PaymentMethod>();
        }
        public Buyer(string identity, string name) : this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }
        public PaymentMethod VerifyOrAddPaymentMethod(
        int cardTypeId, string alias, string cardNumber,
        string securityNumber, string cardHolderName, DateTime expiration, int orderId)
        {

        }
    }
}
