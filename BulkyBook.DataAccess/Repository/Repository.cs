using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBookWeb.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> _dbSet;  

        public Repository(AppDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }
    
        public void Add(T entity)
        {
           // throw new NotImplementedException();
           _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
           // throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();

            //throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            //throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            //throw new NotImplementedException();
        }
    }
}
