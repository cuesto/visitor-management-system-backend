using FluentValidation;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
    {
        private readonly UnitOfWork _uow;

        public EmployeeRequestValidator(UnitOfWork uow)
        {
            _uow = uow;
            //RuleFor(employeeRequest => employeeRequest.Description)
            //    .Must(ValidateDescription)
            //    .WithMessage("Este Departamento ha sido registrado.");
        }

        //private bool ValidateDescription(EmployeeRequest employeeRequest, string description)
        //{
        //    var predicate = PredicateBuilder.New<EmployeeRequest>();

        //    predicate = predicate.And(c => c.EmployeeRequestKey != employeeRequest.EmployeeRequestKey);
        //    predicate = predicate.And(c => c.Description.Trim().ToLower() == employeeRequest.Description.Trim().ToLower());
        //    predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

        //    return _uow.GetGenericRepository<EmployeeRequest>().GetCount(predicate) == 0;
        //}
    }
}
