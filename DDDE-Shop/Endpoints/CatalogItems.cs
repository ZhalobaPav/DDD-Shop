using API.Infrastructure;
using Application.CatalogItems.Commands.CreateCatalogItem;
using Application.CatalogItems.Commands.DeleteCatalogItem;
using Application.CatalogItems.Commands.UpdateCatalogItem;
using Application.CatalogItems.Queries.GetCatalogItemsWithPagination;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public class CatalogItems : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            Console.Write($"Mapping for {this.GetType()}");
            app.MapGroup(this)
                .MapGet(GetCatalogItemsFilter)
                .MapPost(CreateCatalogItem)
                .MapPut(UpdateCatalogItem)
                .MapDelete(DeleteCatalogItem,"{id}");

        }
        public Task<BaseResponse<CatalogItemBriefDto>> GetCatalogItemsFilter(ISender sender, [AsParameters] GetCatalogItemsWithPaginationQuery query, HttpContext context)
        {
            return sender.Send(query);
        }
        public Task<bool> CreateCatalogItem(ISender sender, CreateCatalogItemCommand command)
        {
            return sender.Send<bool>(command);
        }
        public async Task<IResult> DeleteCatalogItem(ISender sender, [FromQuery] int Id)
        {
            await sender.Send(new DeleteCatalogItemCommand(Id));
            return Results.NoContent();
        }
        public async Task<CatalogItemBriefDto> UpdateCatalogItem(ISender sender, [FromBody] UpdateCatalogItemCommand command)
        {
            return await sender.Send(command);
        }
    }
}
