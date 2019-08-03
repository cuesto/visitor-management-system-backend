using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VMS.DataModel.Core.Bases;
using VMS.DataModel.Core.DAL;

namespace VMS.Web.Controllers
{
    public class BaseController : Controller
    {
        public UnitOfWork _uow { get; set; }

        private readonly MyDbContext _context;

        public BaseController(MyDbContext context)
        {
            _context = context;
            _uow = new UnitOfWork(context);
        }

        #region Create
        public async Task<JsonResult> CreateAsync<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Debe revisar todos los datos del formulario");
            }

            var validator = (AbstractValidator<T>)Activator.CreateInstance(typeof(TU), new object[] { _uow });
            var validations = _uow.GetGenericRepository<T>().Insert(entity, validator);

            if (validations.IsValid)
            {
                await _uow.SaveAsync();
                var result = entity;
                return Json(new { Result = "OK", Record = result });
            }

            return Json(new { Result = "ERROR", Message = validations.ToString("|") });
        }

        public JsonResult Create<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Debe llenar todos los datos del formulario");
            }

            var validator = (AbstractValidator<T>)Activator.CreateInstance(typeof(TU), new object[] { _uow });
            var validations = _uow.GetGenericRepository<T>().Insert(entity, validator);

            if (validations.IsValid)
            {
                _uow.Save();
                var result = entity;
                return Json(new { Result = "OK", Record = result });
            }
            return Json(new { Result = "ERROR", Message = validations.ToString("|") });
        }

        #endregion

        #region Update

        public JsonResult Update<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Debe revisar todos los datos del formulario");
            }

            var validator = (AbstractValidator<T>)Activator.CreateInstance(typeof(TU), new object[] { _uow });
            var validations = _uow.GetGenericRepository<T>().Update(entity, validator);

            if (validations.IsValid)
            {
                _uow.Save();
                var result = entity;
                return Json(new { Result = "OK", Record = result });
            }

            return Json(new { Result = "ERROR", Message = validations.ToString("|") });
        }

        public async Task<JsonResult> UpdateAsync<T, TU>(T entity)
            where T : BaseEntity, new()
            where TU : AbstractValidator<T>
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Debe revisar todos los datos del formulario");
            }

            var validator = (AbstractValidator<T>)Activator.CreateInstance(typeof(TU), new object[] { _uow });
            var validations = _uow.GetGenericRepository<T>().Update(entity, validator);

            if (validations.IsValid)
            {
                await _uow.SaveAsync();
                var result = entity;
                return Json(new { Result = "OK", Record = result });
            }

            return Json(new { Result = "ERROR", Message = validations.ToString("|") });
        }

        #endregion

        #region Delete

        public JsonResult Delete<T>(int id) where T : BaseEntity, new()
        {
            try
            {
                _uow.GetGenericRepository<T>().Delete(id);
                _uow.Save();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }

        }

        public async Task<JsonResult> DeleteAsync<T>(int id) where T : BaseEntity, new()
        {
            try
            {
                _uow.GetGenericRepository<T>().Delete(id);
                await _uow.SaveAsync();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }

        }

        public JsonResult Delete<T>(T entity) where T : BaseEntity, new()
        {
            try
            {
                _uow.GetGenericRepository<T>().Delete(entity);
                _uow.Save();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }

        }

        public async Task<JsonResult> DeleteAsync<T>(T entity) where T : BaseEntity, new()
        {
            try
            {
                _uow.GetGenericRepository<T>().Delete(entity);
                await _uow.SaveAsync();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }

        }

        #endregion

    }
}