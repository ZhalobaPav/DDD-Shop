using Domain.Common;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Extensions
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, CatalogContext catalogContext)
        {
            var domainEntities = catalogContext.ChangeTracker
                 .Entries<BaseEntity>()
                 .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            var domainEvents = domainEntities
                .SelectMany(x=>x.Entity.DomainEvents)
                .ToList();
            domainEntities.ToList()
                .ForEach(entity=>entity.Entity.ClearDomainEvents());
            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
