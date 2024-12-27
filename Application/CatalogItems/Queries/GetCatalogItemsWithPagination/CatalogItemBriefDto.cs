namespace Application.CatalogItems.Queries.GetCatalogItemsWithPagination
{
    public class CatalogItemBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        private class Mapping : Profile
        {
            public Mapping() 
            {
                CreateMap<CatalogItem, CatalogItemBriefDto>();
            }
        }
    }
}
