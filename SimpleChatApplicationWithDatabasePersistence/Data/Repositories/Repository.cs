using SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts;
using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repositories
{
    public class Repository<T,TId>:IRepository<T,TId> where T:Entity<TId>
    {
        private ChatDbContext _context;
        private DbSet<T> _set;

        internal Repository(ChatDbContext context)
        {
            _context = context;
        }

        protected DbSet<T> Set
        {
            get { return _set ?? (_set = _context.Set<T>()); }
        }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public Task<List<T>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> condition)
        {
            return Set.Where(condition).AsEnumerable();
        }
        public Task<List<T>> GetByAsync (Expression<Func<T,bool>> condition)
        {
            return Set.Where(condition).ToListAsync();
        }

        public IEnumerable<T> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).AsEnumerable();
        }

        public Task<List<T>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public T FindById(TId id)
        {
            return Set.Find(id);
        }

        public Task<T> FindByIdAsync(TId id)
        {
            return Set.FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> condition)
        {
            return Set.Where(condition).FirstOrDefault();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> condition)
        {
            return Set.Where(condition).FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            Set.Remove(entity);
        }





       
    }
}