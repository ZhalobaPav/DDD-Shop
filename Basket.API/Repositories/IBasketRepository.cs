using Domain.Entities.BasketAggregate;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketModel> GetBasketAsync(string customerId);
        Task<BasketModel> UpdateBasketAsync(BasketModel basket);
        Task<bool> DeleteBasketAsync(string id);
    }
}
