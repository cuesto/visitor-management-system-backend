using System;
using VMS.DataModel.Bases;
using VMS.DataModel.Entities;
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
            if (string.IsNullOrEmpty(entityBase.ModifiedBy))
            {
                entityBase.Created = DateTime.Now;
            }
            else
            {
                entityBase.Modified = DateTime.Now;
            }
        }

        public static User SetPassword(User user)
        {
            if (!user.IsNewPassword)
                return user;

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.password_hash = passwordHash;
            user.password_salt = passwordSalt;
            return user;
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
