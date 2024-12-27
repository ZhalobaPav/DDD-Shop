using Grpc.Core;

namespace Basket.API.Extensions
{
    public static class ServerCallContextIdentityExtensions
    {
        public static string? GetUserIdentity(this ServerCallContext context) => context.GetHttpContext().User.FindFirst("sub")?.Value;
    }
}
