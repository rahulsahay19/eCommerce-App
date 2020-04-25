using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IEcommerceRepository<T> where T : BaseEntity
    {
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();
         Task<T> GetEntityWithSpec(ISpecification<T> spec);
         Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
         Task<int> CounAsync(ISpecification<T> spec);
         // This is for tracking in memory in EF. Hence, kept synchronous.
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);
         
    }
}