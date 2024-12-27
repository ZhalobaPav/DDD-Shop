
using Application.Common.Interfaces;
using Application.Specifications;
using Domain.Common;

namespace Application.CatalogItems.Queries.GetCatalogItemsWithPagination
{
    public class GetCatalogItemsWithPaginationQuery : IRequest<BaseResponse<CatalogItemBriefDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public int? CatalogBrandId { get; init; }
        public int? CategoryId { get; init; }
    }
    public class GetCatalogItemsWithPaginationQueryHandler : IRequestHandler<GetCatalogItemsWithPaginationQuery, BaseResponse<CatalogItemBriefDto>>
    {
        private readonly IRepository<CatalogItem> _itemRepository;
        private readonly IMapper _mapper;

        public GetCatalogItemsWithPaginationQueryHandler(IRepository<CatalogItem> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<CatalogItemBriefDto>> Handle(GetCatalogItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CatalogItemBriefDto>();
            var filterSpec = new CatalogFilterSpecification(request.CatalogBrandId, request.CategoryId);
            int totalItems = await _itemRepository.CountAsync(filterSpec);
            var pagedSpec = new CatalogFilterPaginatedSpecification(
                skip: request.PageNumber * request.PageSize,
                take: request.PageSize,
                brandId: request.CatalogBrandId,
                typeId: request.CategoryId);

            var items = await _itemRepository.ListAsync(pagedSpec);
            response.CatalogItems.AddRange(_mapper.Map<List<CatalogItemBriefDto>>(items));
            if (request.PageSize > 0)
            {
                response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
            }
            else
            {
                response.PageCount = totalItems > 0 ? 1 : 0;
            }
            return response;
        }
    }
}
