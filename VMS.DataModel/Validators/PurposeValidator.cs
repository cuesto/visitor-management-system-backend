using FluentValidation;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class PurposeValidator : AbstractValidator<Purpose>
    {
        private readonly UnitOfWork _uow;

        public PurposeValidator(UnitOfWork uow)
        {
            _uow = uow;
            RuleFor(purpose => purpose)
                .Must(ValidateDescription)
                .WithMessage("Este Propósito ha sido registrado.");
        }

        private bool ValidateDescription(Purpose purpose)
        {
            var predicate = PredicateBuilder.New<Purpose>();

            predicate = predicate.And(c => c.PurposeKey != purpose.PurposeKey);
            predicate = predicate.And(c => c.Description.Trim().ToLower() == purpose.Description.Trim().ToLower());
            predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

            return _uow.GetGenericRepository<Purpose>().GetCount(predicate) == 0;
        }
    }
}
