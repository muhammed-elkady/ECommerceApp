using ECommerceApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();

    }
}
