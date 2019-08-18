using FluentValidation;
using LinqKit;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        private readonly UnitOfWork _uow;

        public DepartmentValidator(UnitOfWork uow)
        {
            _uow = uow;
            RuleFor(department => department)
                .Must(ValidateDescription)
                .WithMessage("Este Departamento ha sido registrado.");
        }

        private bool ValidateDescription(Department department)
        {
            var predicate = PredicateBuilder.New<Department>();

            predicate = predicate.And(c => c.DepartmentKey != department.DepartmentKey);
            predicate = predicate.And(c => c.Description.Trim().ToLower() == department.Description.Trim().ToLower());
            predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

            return _uow.GetGenericRepository<Department>().GetCount(predicate) == 0;
        }
    }
}
