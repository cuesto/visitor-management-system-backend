using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VMS.DataModel.Bases;
using VMS.DataModel.DAL;

namespace VMS.Web.Controllers
{
    public interface IBaseController
    {
        UnitOfWork _uow { get; set; }

        ActionResult<T> Create<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>;
        Task<ActionResult<IEnumerable<T>>> CreateAsync<T, TU>(IEnumerable<T> entities)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>;
        Task<ActionResult<T>> CreateAsync<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>;
        ActionResult<T> Delete<T>(int key) where T : BaseEntity, new();
        ActionResult<T> Delete<T>(T entity) where T : BaseEntity, new();
        Task<ActionResult<T>> DeleteAsync<T>(int key) where T : BaseEntity, new();
        Task<ActionResult<T>> DeleteAsync<T>(T entity) where T : BaseEntity, new();
        ActionResult<T> Update<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>;
        Task<ActionResult<T>> UpdateAsync<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>;
    }
}