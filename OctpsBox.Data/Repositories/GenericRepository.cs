using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OctpsBox.Data.Models;


namespace OctpsBox.Data.GenericRepository
{

     public class GenericRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : class
    {
        #region Variables

        private readonly OctopusBoxContext _context;

       private DbSet<T> _dbset;

        #endregion Variables

        #region Constructor

        public GenericRepository(OctopusBoxContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        #endregion Constructor

        #region GetterMethods
       
        public virtual T Find(int Id)
        {
            return _dbset.Find(Id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbset;
            if (predicate != null)
            {
                return query.Where(predicate);
            }

            return null;
        }

        public virtual IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool descending = true,
            params Expression<Func<T, object>>[] includes)
        {



            IQueryable<T> query = _dbset;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy!=null)
            {
                query = descending ? query.OrderByDescending(orderBy): query.OrderBy(orderBy);

            }
            if (includes !=null)
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }

                //return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            }
           
                return query.AsNoTracking();
            
        }
        
        #endregion GetterMethods

        #region SetterMethods

  
        public virtual T Update(T entityToUpdate, bool saveChange = false)
        {
            _dbset.Update(entityToUpdate);
            if (saveChange)
                Save();
            return entityToUpdate;
        }

     
        public virtual T Add(T entity, bool saveChange = false)
        {
            _dbset.Add(entity);
            if (saveChange)
                Save();
            return entity;
        }
        public virtual void Delete(int Id, bool saveChange = false)
        {
            Delete(Find(Id),saveChange);
        }

      
        public virtual void Delete(T entityToDelete, bool saveChange=false)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Attach(entityToDelete);
            }
            _dbset.Remove(entityToDelete);
            if (saveChange)
                Save();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        #endregion SetterMethods
    }

}
