using FluentValidation;
using LinqKit;
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
            RuleFor(employee => employee)
                .Must(ValidateTaxNumber)
                .WithMessage("Este empleado ha sido registrado.");
        }

        private bool ValidateTaxNumber(Employee employee)
        {
            var predicate = PredicateBuilder.New<Employee>();

            predicate = predicate.And(c => c.EmployeeKey != employee.EmployeeKey);
            predicate = predicate.And(c => c.EmployeeId.Trim().ToLower() == employee.EmployeeId.Trim().ToLower());
            predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

            return _uow.GetGenericRepository<Employee>().GetCount(predicate) == 0;
        }
    }
}
