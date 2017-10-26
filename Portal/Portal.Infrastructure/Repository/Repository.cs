using Microsoft.EntityFrameworkCore;
using Portal.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = DbSet;
            return await Task.Run(() => (query.ToList()));
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }


        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            DbSet.Add(entity);

            await _context.SaveChangesAsync();

            return _context.Entry(entity).Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate, int entityId)
        {
            try
            {
                DbSet.Update(entityToUpdate);

                await _context.SaveChangesAsync();

                return _context.Entry(entityToUpdate).Entity;
            }
            catch (Exception exception)
            {
                throw;
            }

        }
        

        public void Delete(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
        }

        public Task<TEntity> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
