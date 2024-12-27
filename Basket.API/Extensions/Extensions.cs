using Basket.API.Repositories;

namespace Basket.API.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.AddRedisClient("redis");
            builder.Services.AddSingleton<IBasketRepository, RedisBasketRepository>();
        }
    }
}
