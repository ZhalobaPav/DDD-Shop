using Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Mapping
{
    public static class MappingExtension
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination:class
            => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);    
                
    }
}
