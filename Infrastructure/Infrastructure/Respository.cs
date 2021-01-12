using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Infrastructure
{
    public abstract class Respository<T> : IRespository<T> where T : class
    {

        private StoreContext _context;

        protected IDbFactory _dbFactory
        {
            get;
            private set;
        }

        private StoreContext StoreContext
        {
            get
            {
                return _context ?? (_context = _dbFactory.Init());
            }
        }

        private DbSet<T> dbSet;

        protected Respository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            dbSet = StoreContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
             dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var listRemove = dbSet.Where(where);
            dbSet.RemoveRange(listRemove);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Find(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(Guid Id)
        {
            return dbSet.Find(Id);
        }

        public virtual IEnumerable<T> GetList(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual IQueryable<T> _GetList(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = dbSet;
            foreach(var expression in includes)
            {
                result = result.Include(expression);
            }
            return result;
        }

        public IQueryable<T> _GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = dbSet.Where(where);
            foreach (var expression in includes)
            {
                result = result.Include(expression);
            }
            return result;
        }
    }
}
