using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts
{
    public interface IRepository<T, TId> where T : Entity<TId>
    {
        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync();

        IEnumerable<T> GetBy(Expression<Func<T, bool>> condition);
        Task<List<T>> GetByAsync (Expression<Func<T,bool>> condition);


        IEnumerable<T> PageAll(int skip, int take);
        Task<List<T>> PageAllAsync(int skip, int take);

        T Find(Expression<Func<T, bool>> condition);
        Task<T> FindAsync(Expression<Func<T, bool>> condition);

        T FindById(TId id);
        Task<T> FindByIdAsync(TId id);

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}