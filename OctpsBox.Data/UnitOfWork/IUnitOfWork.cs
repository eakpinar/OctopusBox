using System;
using OctpsBox.Data.GenericRepository;
using OctpsBox.Data.Models;

namespace OctpsBox.Data.UnitOfWork
{
        public interface IUnitOfWork : IDisposable
        {
            IGenericRepository<T> GetRepository<T>() where T : class;

            bool BeginNewTransaction();

            bool RollBackTransaction();

            OctopusBoxContext GetContext();

            int SaveChanges(bool ensureAutoHistory);
        }
}