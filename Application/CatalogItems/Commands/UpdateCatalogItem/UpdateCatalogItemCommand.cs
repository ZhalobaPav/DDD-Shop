using Application.CatalogItems.Queries.GetCatalogItemsWithPagination;
using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using Domain.Events.CatalogItems;
using System.ComponentModel.DataAnnotations;

namespace Application.CatalogItems.Commands.UpdateCatalogItem
{
    public class UpdateCatalogItemCommand:IRequest<CatalogItemBriefDto>
    {
        public int Id { get; set; }
        [Range(1, 10000)]
        public int CatalogBrandId { get; set; }
        [Range(1, 10000)]
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public string PictureBase64 { get; set; }
        public string PictureUri { get; set; }
        public string PictureName { get; set; }
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
    }
    public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, CatalogItemBriefDto>
    {
        private readonly IRepository<CatalogItem> _repository;

        public UpdateCatalogItemCommandHandler(IRepository<CatalogItem> repository)
        {
            _repository = repository;
        }
        public async Task<CatalogItemBriefDto> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _repository.GetByIdAsync(request.Id);

            Guard.Against.NotFound(request.Id, existingEntity);

            CatalogItem.CatalogItemDetails details = new(request.Name, request.Description, request.Price);
            existingEntity.UpdateDetails(details);
            existingEntity.UpdateBrand(request.CatalogBrandId);
            existingEntity.UpdateCategory(request.CategoryId);

            await _repository.UpdateAsync(existingEntity);
            existingEntity.AddDomainEvent(new CatalogItemUpdatedEvent(existingEntity));
            var dto = new CatalogItemBriefDto
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Description = existingEntity.Description,
                Price = existingEntity.Price,
                BrandId = existingEntity.BrandId,
                CategoryId = existingEntity.CategoryId,
                PictureUri = existingEntity.PictureUri
            };
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return dto;
        }
    }
}
