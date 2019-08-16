using FluentValidation;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Text;
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
            //RuleFor(blackList => blackList.Description)
            //    .Must(ValidateDescription)
            //    .WithMessage("Este Departamento ha sido registrado.");
        }

    //    private bool ValidateDescription(BlackList blackList, string description)
    //    {
    //        var predicate = PredicateBuilder.New<BlackList>();

    //        predicate = predicate.And(c => c.BlackListKey != blackList.BlackListKey);
    //        predicate = predicate.And(c => c.Description.Trim().ToLower() == blackList.Description.Trim().ToLower());
    //        predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

    //        return _uow.GetGenericRepository<BlackList>().GetCount(predicate) == 0;
    //    }
    }
}
