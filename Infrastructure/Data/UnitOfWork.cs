using System;
using System.Collections;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceContext _context;

        // Any repository is getting used as part UOW, will be store in hash table.
        private Hashtable _repositories; 
        public UnitOfWork(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEcommerceRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            // Check type of the entity
            var type = typeof(TEntity).Name;

            // Check whether hash table contains entry with this name
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EcommerceRepository<>);
                // If we don't have a repository for this type, then create a instance of that repo
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IEcommerceRepository<TEntity>) _repositories[type];
        }
    }
}