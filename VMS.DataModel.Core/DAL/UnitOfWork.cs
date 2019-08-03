using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VMS.DataModel.Core.Bases;

namespace VMS.DataModel.Core.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;

        public IGenericRepository<T> GetGenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_dbContext);
        }

        public UnitOfWork(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
             .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

    }
}
