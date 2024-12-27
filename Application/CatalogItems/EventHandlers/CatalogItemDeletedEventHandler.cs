using Domain.Events.CatalogItems;
using Microsoft.Extensions.Logging;

namespace Application.CatalogItems.EventHandlers
{
    public class CatalogItemDeletedEventHandler : INotificationHandler<CatalogItemDeletedEvent>
    {
        private readonly ILogger<CatalogItemCreatedEventHandler> _logger;

        public CatalogItemDeletedEventHandler(ILogger<CatalogItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(CatalogItemDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("\n CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
