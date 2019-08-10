using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VMS.DataModel.Enums;

namespace VMS.DataModel.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        #region Get
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);

        T GetById(object id);

        Task<T> GetByIDAsync(object id);

        int GetCount(Expression<Func<T, bool>> predicate);
        #endregion

        #region Insert
        void Insert(T entity);
        ValidationResult Insert(T entity, AbstractValidator<T> validator);
        void Insert(IEnumerable<T> entities);
        #endregion

        #region Delete
        void Delete(object id);
        void Delete(T entityToDelete);
        void Gone(T entities);
        void Gone(IEnumerable<T> entities);
        #endregion

        #region Update
        void Update(T entityToUpdate);
        ValidationResult Update(T entityToUpdate, AbstractValidator<T> validator);
        #endregion

        void Audit(MyDbContext context, T entity, DbOperationType OpType);

        List<T> PGetProcedure(string procedureName, params (string name, object value)[] Parameters);

        List<T> PGetProcedure(string procedureName, out int procResult, params (string name, object value)[] Parameters);

        void PExecuteProcedure(string procedureName, params (string name, object value)[] Parameters);
    }
}
