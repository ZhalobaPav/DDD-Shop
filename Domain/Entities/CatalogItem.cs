using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Entities
{
    public class CatalogItem:BaseAuditableEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CategoryId { get; private set; }
        public Category? Category { get; private set; }
        public int BrandId { get; private set; }
        public Brand? CatalogBrand { get; private set; }
        public CatalogItem(int categoryId,
        int catalogBrandId,
        string description,
        string name,
        decimal price,
        string pictureUri)
        {
            CategoryId = categoryId;
            BrandId = catalogBrandId;
            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }
#pragma warning disable CS8618
        public CatalogItem()
        { }
        public void UpdateDetails(CatalogItemDetails details)
        {
            Guard.Against.NullOrEmpty(details.Name, nameof(details.Name));
            Guard.Against.NullOrEmpty(details.Description, nameof(details.Description));
            Guard.Against.NegativeOrZero(details.Price, nameof(details.Price));

            Name = details.Name;
            Description = details.Description;
            Price = details.Price;
        }
        public void UpdateBrand(int catalogBrandId)
        {
            Guard.Against.Zero(catalogBrandId, nameof(catalogBrandId));
            BrandId = catalogBrandId;
        }
        public void UpdateCategory(int categoryId)
        {
            Guard.Against.Zero(categoryId, nameof(categoryId));
            CategoryId = categoryId;
        }
        public readonly record struct CatalogItemDetails
        {
            public string? Name { get; }
            public string? Description { get; }
            public decimal Price { get; }

            public CatalogItemDetails(string? name, string? description, decimal price)
            {
                Name = name;
                Description = description;
                Price = price;
            }
        }
    }
}
