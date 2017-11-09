using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int entityId);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, int entityId);
        Task Delete(TEntity entityToDelete);
    }
}
