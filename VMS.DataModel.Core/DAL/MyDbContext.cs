﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using VMS.DataModel.Core.Entities;

namespace VMS.DataModel.Core.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeRequest> EmployeeRequest { get; set; }
        public virtual DbSet<Purpose> Purpose { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.Relational().TableName = entityType.DisplayName();

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }


            base.OnModelCreating(modelBuilder);
        }

    }
}
