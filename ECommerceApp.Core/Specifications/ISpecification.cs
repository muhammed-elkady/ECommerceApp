using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ECommerceApp.Core.Specifications
{
    public interface ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; }
        public Expression<Func<T, object>> OrderBy { get; }
        public Expression<Func<T, object>> OrderByDesc { get; }
        public int Skip { get; }
        public int Take { get; }
        public bool IsPagingEnabled { get; }
    }
}
