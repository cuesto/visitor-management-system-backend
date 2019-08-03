using System;
using VMS.DataModel.Core.Bases;
using VMS.DataModel.Core.Enums;

namespace VMS.DataModel.Core.Services
{
    public static class BaseEntityServices
    {
        /// <summary>
        ///     Sets the values.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entityBase">The entity base.</param>
        public static void SetValues<T>(this T entityBase) where T : BaseEntity
        {
            var userName = Environment.UserName == null
                ? ""
                : Environment.UserName;

            if (string.IsNullOrEmpty(entityBase.CreatedBy))
            {
                entityBase.Created = DateTime.Now;
                entityBase.CreatedBy = userName;
                entityBase.IsDeleted = IsDeleted.False;
            }
            else
            {
                entityBase.ModifiedBy = userName;
                entityBase.Modified = DateTime.Now;
            }
        }
    }
}
