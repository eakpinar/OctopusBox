using System;
using System.Linq;
using System.Linq.Expressions;

namespace OctpsBox.Data.GenericRepository
{
    public interface IQueryRepository<T> where T : class
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Find(int Id);
        IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool descending = true,
            params Expression<Func<T, object>>[] includes);
    }
    public interface ICommandRepository<T> where T : class
    {
        T Add(T entity, bool saveChange = false);
        T Update(T entityToUpdate, bool saveChange = false);
        int Save();

        void Delete(int Id, bool saveChange = false);
        void Delete(T entityToDelete, bool saveChange = false);
    }

}