using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OctpsBox.Data.GenericRepository;
using OctpsBox.Data.Models;

namespace OctpsBox.Data.UnitOfWork
{
  
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables

        private readonly OctopusBoxContext _context;

        private IDbContextTransaction _transation;
        private bool _disposed;

        #endregion Variables

        #region Constructor

     
        public UnitOfWork(OctopusBoxContext context)
        {
            _context = context;
        }
        public OctopusBoxContext GetContext()
        {
            return _context;
        }

        #endregion Constructor

        #region BusinessSection

        public IQueryRepository<T> GetQueryRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public ICommandRepository<T> GetCommandRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
       
        public bool BeginNewTransaction()
        {
            try
            {
                _transation = _context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
        public bool RollBackTransaction()
        {
            try
            {
                _transation.Rollback();
                _transation = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            var transaction = _transation != null ? _transation : _context.Database.BeginTransaction();
            using (transaction)
            {
                try
                {
                    if (_context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }

                    if (ensureAutoHistory)
                    {
                        _context.EnsureAutoHistory();
                    }
                    int result = _context.SaveChanges();

                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error on save changes ", ex);
                }
            }
        }

        #endregion BusinessSection

        #region DisposingSection

       
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion DisposingSection
    }
}
    
