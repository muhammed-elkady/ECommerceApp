using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }
    }
}
