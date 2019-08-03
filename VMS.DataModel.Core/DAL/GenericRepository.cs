using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VMS.DataModel.Core.Bases;
using VMS.DataModel.Core.Enums;
using VMS.DataModel.Core.Services;

namespace VMS.DataModel.Core.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BasdeEntity
    {
        private readonly MyDbContext _dbContext;
        private DbSet<T> _dbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => _dbSet;

        public GenericRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            // Solo registros Reales
            return query.Where(c => c.IsDeleted == IsDeleted.False).AsEnumerable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var data = _dbContext
                    .Set<T>()
                    .Where(x => x.IsDeleted != IsDeleted.False);

            if (predicate != null)
                data = data.Where(predicate);

            return data;
        }

        //public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
        //                                          string includeProperties = "")
        //{
        //    IQueryable<T> query = _dbSet.AsQueryable();


        //    query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        //                             .Aggregate(query, (current, includeProperty) =>
        //                                               current.Include(includeProperty));

        //    if (filter == null)
        //        filter = PredicateBuilder.New<T>(true);

        //    filter = filter.And(c => c.IsDeleted == IsDeleted.False);

        //    if (filter != null)
        //    {
        //        query = query.AsExpandable().Where(filter);
        //    }
        //    return query;
        //}

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }


        /// <summary>
        ///     Get count of selection
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        ///     count of selection
        /// </returns>
        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return GetAll(predicate).AsNoTracking().Count();
        }

        #endregion

        #region Insert
        public virtual ValidationResult Insert(T entity, AbstractValidator<T> validator)
        {
            ValidationResult results = validator.Validate(entity);
            bool validationSucceeded = results.IsValid;
            //
            if (validationSucceeded)
            {
                entity.SetValues();
                _dbSet.Add(entity);
            }
            return results;
        }

        public virtual void Insert(T entity)
        {
            entity.SetValues();
            _dbSet.Add(entity);
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            var enumerable = entities as List<T> ?? entities.ToList();
            enumerable.ForEach(
                entity =>
                {
                    entity.SetValues();
                });
            _dbSet.AddRange(enumerable);
        }

        #endregion

        #region Update

        /// <summary>
        ///     Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        public virtual void Update(T entityToUpdate)
        {
            entityToUpdate.SetValues();
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        ///     Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        /// <param name="validator">The validator.</param>
        /// <returns></returns>
        public virtual ValidationResult Update(T entityToUpdate, AbstractValidator<T> validator)
        {
            ValidationResult results = validator.Validate(entityToUpdate);
            bool validationSucceeded = results.IsValid;
            //
            if (validationSucceeded)
            {
                entityToUpdate.SetValues();
                _dbSet.Attach(entityToUpdate);
                _dbContext.Entry(entityToUpdate).State = EntityState.Modified;

            }
            return results;
        }

        #endregion

        #region Delete

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);

            entityToDelete.IsDeleted = IsDeleted.True;
            Update(entityToDelete);
        }

        /// <summary>
        ///     Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public virtual void Delete(T entityToDelete)
        {
            entityToDelete.IsDeleted = IsDeleted.True;
            Update(entityToDelete);
        }

        /// <summary>
        /// Borra los datos de manera definitiva de la base de datos.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Gone(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Borra los datos de manera definitiva de la base de datos.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Gone(T entities)
        {
            _dbSet.Remove(entities);
        }

        #endregion

        #region implemented


        public Task<T> GetByIDAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Audit(MyDbContext context, T entity, DbOperationType OpType)
        {
            throw new NotImplementedException();
        }

        public List<T> PGetProcedure(string procedureName, params (string name, object value)[] Parameters)
        {
            throw new NotImplementedException();
        }

        public List<T> PGetProcedure(string procedureName, out int procResult, params (string name, object value)[] Parameters)
        {
            throw new NotImplementedException();
        }

        public void PExecuteProcedure(string procedureName, params (string name, object value)[] Parameters)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
