using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
                            where TEntity : EntidadeBase
                            where TContext : DbContext
    {
        protected readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public void Dispose()
        {
            try
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> CreatAsync(TEntity entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                await SaveAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                int retorno = await _context.SaveChangesAsync();
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        // Método para obter todos os itens com um filtro (Método Adicional)
        public virtual IEnumerable<TEntity> GetAllFullEntities(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Where(where).ToList();
        }

        // Método assíncrono para obter um único item com um filtro
        public virtual async Task<TEntity> GetFullEntityAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<TEntity>> Query(List<Expression<Func<TEntity, bool>>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes)
        {
            var result = DbSet.AsQueryable().AsNoTracking();

            foreach (var condition in where)
            {
                result = result.Where(condition);
            }

            if (includes != null)
            {
                result = includes(result);
            }

            return await result.ToListAsync();
        }
        public async Task<TEntity> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = DbSet.AsQueryable().AsNoTracking();

            result = result.Where(where);

            if (includes != null)
            {
                result = includes(result);
            }

            return await result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> Select(List<Expression<Func<TEntity, bool>>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = DbSet.AsQueryable().AsNoTracking();

            foreach (var filter in where)
            {
                result = result.Where(filter);
            }

            // Aplicar includes
            if (includes != null)
            {
                result = includes(result);
            }

            return await result.ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes)
        {
            var result = DbSet.AsQueryable().AsNoTracking();

            result = result.Where(where);


            // Aplicar includes
            if (includes != null)
            {
                result = includes(result);
            }

            return await result.ToListAsync();

        }

        public IQueryable<TEntity> GetPaginated(List<Expression<Func<TEntity, bool>>> filters, int pageNumber, int pageSize, Expression<Func<TEntity, object>> orderBy, bool? descending = null)
        {

            var result = DbSet.AsQueryable();
            result = Includes(result);
            var counter = result.Count();
            foreach (var filter in filters)
            {
                result = result.Where(filter);
            }

            if (descending.HasValue)
                result = result.OrderByDescending(orderBy);
            else
                result = result.OrderBy(orderBy);

            if (pageNumber > 0 && pageSize > 0)
                result = result.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

            return result;
        }

        protected virtual IQueryable<TEntity> Includes(IQueryable<TEntity> query) => query;

        public async Task<int> GetTotalCount(List<Expression<Func<TEntity, bool>>> filters)
        {
            var result = DbSet.AsQueryable();
            foreach (var filter in filters)
            {
                result = result.Where(filter);
            }
            return await result.CountAsync();
        }
    }
}
