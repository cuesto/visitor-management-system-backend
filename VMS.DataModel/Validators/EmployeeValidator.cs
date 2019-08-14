using FluentValidation;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        private readonly UnitOfWork _uow;

        public EmployeeValidator(UnitOfWork uow)
        {
            _uow = uow;
            RuleFor(employee => employee.TaxNumber)
                .Must(ValidateTaxNumber)
                .WithMessage("Este empleado ha sido registrado.");
        }

        private bool ValidateTaxNumber(Employee employee, string taxNumber)
        {
            var predicate = PredicateBuilder.New<Employee>();

            predicate = predicate.And(c => c.EmployeeKey != employee.EmployeeKey);
            predicate = predicate.And(c => c.TaxNumber.Trim().ToLower() == employee.TaxNumber.Trim().ToLower());
            predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

            return _uow.GetGenericRepository<Employee>().GetCount(predicate) == 0;
        }
    }
}
