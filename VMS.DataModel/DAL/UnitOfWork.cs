using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VMS.DataModel.Bases;

namespace VMS.DataModel.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        Task<int> SaveAsync();
        IGenericRepository<T> GetGenericRepository<T>() where T : BaseEntity;
        void RejectChanges();
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

        public int Save()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
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
