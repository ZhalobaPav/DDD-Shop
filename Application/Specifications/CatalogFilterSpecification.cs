namespace Application.Specifications
{
    public class CatalogFilterSpecification:Specification<CatalogItem>
    {
        public CatalogFilterSpecification(int? brandId, int? categoryId)
        {
            Query.Where(i => (!brandId.HasValue || i.BrandId == brandId) &&
                (!categoryId.HasValue || i.CategoryId == categoryId));
        }
    }
}
