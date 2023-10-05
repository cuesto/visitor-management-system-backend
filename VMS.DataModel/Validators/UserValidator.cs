using FluentValidation;
using LinqKit;
using System;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly UnitOfWork _uow;

        public UserValidator(UnitOfWork uow)
        {
            _uow = uow;
            RuleFor(user => user)
                .Must(ValidateDescription)
                .WithMessage("Este Usuario ha sido registrado.");
        }

        private bool ValidateDescription(User user)
        {
            var predicate = PredicateBuilder.New<User>();

            predicate = predicate.And(c => c.UserKey != user.UserKey);
            predicate = predicate.And(c => c.Name.Trim().ToLower() == user.Name.Trim().ToLower());
            predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

            return _uow.GetGenericRepository<User>().GetCount(predicate) == 0;
        }

    }
}
