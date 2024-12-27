namespace Application.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId)
            : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query
                .Where(i => (!brandId.HasValue || i.BrandId == brandId) &&
                (!typeId.HasValue || i.CategoryId == typeId))
                .Skip(skip).Take(take);
        }
    }
}
