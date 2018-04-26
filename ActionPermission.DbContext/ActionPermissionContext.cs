using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using ActionPermission.EntityMap;

namespace ActionPermission.Context
{
    public class ActionPermissionContext:DbContext
    {
        public ActionPermissionContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActionPermissionMap());
            modelBuilder.ApplyConfiguration(new ActionPermissionRoleMap());
            modelBuilder.ApplyConfiguration(new ActionPermissionUserMap());
            modelBuilder.ApplyConfiguration(new UserPermissionMap());
            modelBuilder.ApplyConfiguration(new RolePermissionMap());
            modelBuilder.ApplyConfiguration(new RoleUserMap()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
