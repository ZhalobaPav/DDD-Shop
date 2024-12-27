using API.Infrastructure;
using Domain.Common;
using MediatR;

namespace API.Endpoints
{
    public class Category : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(GetCategories);
        }
        public Task<BaseResponse<Category>> GetCategories(ISender sender)
        {
            throw new NotImplementedException ();
        }
    }
}
