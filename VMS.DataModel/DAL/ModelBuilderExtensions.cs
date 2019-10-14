using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.DataModel.Entities;
using VMS.DataModel.Services;

namespace VMS.DataModel.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var user = new User
            {
                UserKey = 1,
                Name = "admin",
                Email = "administrator@mail.com",
                IsNewPassword = true,
                Password = "123",
                RoleKey=1,
                Created = DateTime.Now,
                CreatedBy = "System",
                IsDeleted = Enums.IsDeleted.False,
            };

            user = BaseEntityServices.SetPassword(user);

            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        RoleKey = 1,
                        Name = "administrator",
                        Description = "Administrator",
                        Created = DateTime.Now,
                        CreatedBy = "System",
                        IsDeleted = Enums.IsDeleted.False,
                    });

            modelBuilder.Entity<User>().HasData(user);
        }
    }
}
