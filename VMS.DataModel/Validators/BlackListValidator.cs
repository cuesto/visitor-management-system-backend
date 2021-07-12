using FluentValidation;
using LinqKit;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class BlackListValidator : AbstractValidator<BlackList>
    {
        private readonly UnitOfWork _uow;

        public BlackListValidator(UnitOfWork uow)
        {
            _uow = uow;
            RuleFor(blackList => blackList)
                .Must(ValidateEndDate)
                .WithMessage("La Fecha Fin no puede ser menor a la Fecha Inicio.");

            RuleFor(blackList => blackList)
                .Must(ValidateCurrentBlock)
                .WithMessage("Ya esta persona tiene una restricción en esta fecha.");

        }

        private bool ValidateCurrentBlock(BlackList blackList)
        {
            var predicate = PredicateBuilder.New<BlackList>();

            predicate = predicate.And(c => c.BlackListKey != blackList.BlackListKey);
            predicate = predicate.And(c => c.TaxNumber == blackList.TaxNumber);
            predicate = predicate.And(c => c.StartDate <= blackList.StartDate);
            predicate = predicate.And(c => c.EndDate >= blackList.EndDate);
            predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

            return _uow.GetGenericRepository<BlackList>().GetCount(predicate) == 0;
        }

        private bool ValidateEndDate(BlackList blackList)
        {
            if (blackList.EndDate != null && blackList.StartDate > blackList.EndDate)
                return false;

            return true;
        }
    }
}
