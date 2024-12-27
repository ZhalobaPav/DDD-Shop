using Domain.Events.CatalogItems;
using Microsoft.Extensions.Logging;

namespace Application.CatalogItems.EventHandlers
{
    public class CatalogItemCreatedEventHandler : INotificationHandler<CatalogItemCreatedEvent>
    {
        private readonly ILogger<CatalogItemCreatedEventHandler> _logger;

        public CatalogItemCreatedEventHandler(ILogger<CatalogItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(CatalogItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
