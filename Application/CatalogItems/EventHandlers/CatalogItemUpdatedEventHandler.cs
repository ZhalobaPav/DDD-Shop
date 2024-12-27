using Domain.Events.CatalogItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.CatalogItems.EventHandlers
{
    public class CatalogItemUpdatedEventHandler : INotificationHandler<CatalogItemUpdatedEvent>
    {
        private readonly ILogger<CatalogItemUpdatedEventHandler> _logger;

        public CatalogItemUpdatedEventHandler(ILogger<CatalogItemUpdatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(CatalogItemUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("\n CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
