using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.DataModel.Validators
{
    public class RoleValidator : AbstractValidator<Role>
    {
        private readonly UnitOfWork _uow;

        public RoleValidator(UnitOfWork uow)
        {
            _uow = uow;
            //RuleFor(role => role.Description)
            //    .Must(ValidateDescription)
            //    .WithMessage("Este Departamento ha sido registrado.");
        }

        //private bool ValidateDescription(Role role, string description)
        //{
        //    var predicate = PredicateBuilder.New<Role>();

        //    predicate = predicate.And(c => c.RoleKey != role.RoleKey);
        //    predicate = predicate.And(c => c.Description.Trim().ToLower() == role.Description.Trim().ToLower());
        //    predicate = predicate.And(c => c.IsDeleted == Enums.IsDeleted.False);

        //    return _uow.GetGenericRepository<Role>().GetCount(predicate) == 0;
        //}
    }
}
