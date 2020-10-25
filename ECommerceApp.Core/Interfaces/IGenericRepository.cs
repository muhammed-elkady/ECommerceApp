using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> spec);

    }
}
