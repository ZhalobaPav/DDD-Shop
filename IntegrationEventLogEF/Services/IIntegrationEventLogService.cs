using EventBus.Events;
using Microsoft.EntityFrameworkCore.Storage;

namespace IntegrationEventLogEF.Services
{
    public interface IIntegrationEventLogService
    {
        Task MarkEventAsFailedAsync(Guid eventId);
        Task MarkEventAsInProgressAsync(Guid eventId);
        Task MarkEventAsPublishedAsync(Guid eventId);
        Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId);
        Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction);
    }
}