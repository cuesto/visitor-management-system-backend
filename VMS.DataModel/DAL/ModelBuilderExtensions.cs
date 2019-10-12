using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.DataModel.Entities;

namespace VMS.DataModel.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        RoleKey = 1,
                        Name = "Admin",
                        Description = "Administrador",
                        Created = DateTime.Now,
                        CreatedBy = "System",
                        IsDeleted = Enums.IsDeleted.False,
                    });
        }
    }
}
