using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using Domain.Events.CatalogItems;

namespace Application.CatalogItems.Commands.DeleteCatalogItem
{
    public record DeleteCatalogItemCommand(int Id):IRequest;

    public class DeleteCatalogItemCommandHandler:IRequestHandler<DeleteCatalogItemCommand>
    {
        private readonly IRepository<CatalogItem> _repository;

        public DeleteCatalogItemCommandHandler(IRepository<CatalogItem> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            Guard.Against.NotFound(request.Id, entity);
            await _repository.DeleteAsync(entity, cancellationToken);
            entity.AddDomainEvent(new CatalogItemDeletedEvent(entity));
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
