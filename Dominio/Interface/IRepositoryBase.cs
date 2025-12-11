using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        // Método para obter uma entidade por seu ID
        Task<T> GetByIdAsync(int id);

        // Método para obter todas as entidades
        Task<IEnumerable<T>> GetAllAsync();

        // Método para adicionar uma nova entidade
        Task<T> CreatAsync(T entity);

        // Método para atualizar uma entidade existente
        Task UpdateAsync(T entity);

        // Método para excluir uma entidade pelo ID
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> Query(List<System.Linq.Expressions.Expression<Func<T, bool>>> where, Func<IQueryable<T>, IQueryable<T>> includes);
        Task<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> where, Func<IQueryable<T>, IQueryable<T>> includes = null);
        Task<IEnumerable<T>> Select(List<System.Linq.Expressions.Expression<Func<T, bool>>> where, Func<IQueryable<T>, IQueryable<T>> includes = null);
        Task<IEnumerable<T>> Select(System.Linq.Expressions.Expression<Func<T, bool>> where, Func<IQueryable<T>, IQueryable<T>> includes);
        IQueryable<T> GetPaginated(List<Expression<Func<T, bool>>> filters, int pageNumber, int pageSize, Expression<Func<T, object>> orderBy, bool? descending = null);
        Task<int> GetTotalCount(List<Expression<Func<T, bool>>> filters);
    }
}
