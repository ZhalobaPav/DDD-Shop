namespace Domain.Common
{
    public class BaseResponse<T> where T : class
    {
        public List<T> CatalogItems { get; set; } = new List<T>();
        public int PageCount { get; set; }
        public int? TotalItems { get; set; }
    }
}
