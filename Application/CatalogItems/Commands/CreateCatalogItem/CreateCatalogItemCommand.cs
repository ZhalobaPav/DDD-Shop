using Application.Common.Interfaces;
using Application.Specifications;
using Ardalis.Specification;
using Domain.Events.CatalogItems;

namespace Application.CatalogItems.Commands.CreateCatalogItem
{
    public class CreateCatalogItemCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CategoryId { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CreateCatalogItemCommand(string name, string description, decimal price, string pictureUri, int categoryId, int catalogBrandId)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
            CategoryId = categoryId;
            CatalogBrandId = catalogBrandId;
        }
    }
    public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, bool>
    {
        private readonly IRepository<CatalogItem> _repository;

        public CreateCatalogItemCommandHandler(IRepository<CatalogItem> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var itemSpec = new CatalogItemNameSpecification(request.Name);
            var existingCataloogItem = await _repository.CountAsync(itemSpec);
            if (existingCataloogItem > 0)
            {
                throw new Exception($"A catalogItem with name {request.Name} already exists");
            }
            var newItem = new CatalogItem(request.CategoryId, request.CatalogBrandId, request.Description, request.Name, request.Price, request.PictureUri);
            newItem.AddDomainEvent(new CatalogItemCreatedEvent(newItem));
            await _repository.AddAsync(newItem);
            return await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
