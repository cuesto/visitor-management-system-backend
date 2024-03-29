﻿using System;
using VMS.DataModel.Bases;
using VMS.DataModel.Enums;

namespace VMS.DataModel.Services
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
            //var userName = Environment.UserName == null
            //    ? ""
            //    : Environment.UserName;

            if (string.IsNullOrEmpty(entityBase.ModifiedBy))
            {
                entityBase.Created = DateTime.Now;
                //entityBase.CreatedBy = userName;
                //entityBase.IsDeleted = IsDeleted.False;
            }
            else
            {
                //entityBase.ModifiedBy = userName;
                entityBase.Modified = DateTime.Now;
            }
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
