using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Basket.API.Repositories
{
    public class RedisBasketRepository(ILogger<RedisBasketRepository> logger, IConnectionMultiplexer redis): IBasketRepository
    {
        private readonly IDatabase _database = redis.GetDatabase();
        private static RedisKey BasketKeyPrefix = "/basket/"u8.ToArray();

        private static RedisKey GetBasketKey(string key) => BasketKeyPrefix.Append(key);

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(GetBasketKey(id));
        }

        public async Task<BasketModel> GetBasketAsync(string customerId)
        {
            using var data = await _database.StringGetLeaseAsync(customerId);
            if(data is null || data.Length == 0)
            {
                return null;
            }
            return JsonSerializer.Deserialize(data.Span, BasketSerializationContext.Default.Basket);
        }
        public async Task<BasketModel> UpdateBasketAsync(BasketModel basket)
        {
            var json = JsonSerializer.SerializeToUtf8Bytes(basket, BasketSerializationContext.Default.Basket);
            var created = await _database.StringSetAsync(GetBasketKey(basket.BuyerId), json);
            if (!created)
            {
                logger.LogInformation("Problem occurred persisting the item.");
                return null;
            }


            logger.LogInformation("Basket item persisted successfully.");
            return await GetBasketAsync(basket.BuyerId);
        }
    }
}
[JsonSerializable(typeof(Domain.Entities.BasketAggregate.Basket))]
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
public partial class BasketSerializationContext : JsonSerializerContext
{

}
