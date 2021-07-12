using FluentValidation;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class VisitorValidator : AbstractValidator<Visitor>
    {
        private readonly UnitOfWork _uow;

        public VisitorValidator(UnitOfWork uow)
        {
            _uow = uow;
            //RuleFor(visitor => visitor.Description)
            //    .Must(ValidateDescription)
            //    .WithMessage("Este Departamento ha sido registrado.");
        }

        //private bool ValidateDescription(Visitor visitor, string description)
        //{
        //    var predicate = PredicateBuilder.New<Visitor>();

        //    predicate = predicate.And(c => c.VisitorKey != visitor.VisitorKey);
        //    predicate = predicate.And(c => c.Description.Trim().ToLower() == visitor.Description.Trim().ToLower());
        //    predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

        //    return _uow.GetGenericRepository<Visitor>().GetCount(predicate) == 0;
        //}
    }
}
