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
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Name = "administrator",
                        Role = new Role
                        {
                            Name = "Admin",
                            Description = "Administrador",
                            Created = DateTime.Now,
                            CreatedBy = "System",
                            IsDeleted = Enums.IsDeleted.False,

                        },
                        Created = DateTime.Now,
                        CreatedBy = "System",
                        IsDeleted = Enums.IsDeleted.False,
                    }

                );

            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Name = "Admin",
                        Description = "Administrador",
                        Created = DateTime.Now,
                        CreatedBy = "System",
                        IsDeleted = Enums.IsDeleted.False,

                    }

                ) ;
        }
    }
}
