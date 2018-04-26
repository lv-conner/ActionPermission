using ActionPermission.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.EntityMap
{
    public class ActionPermissionMap : IEntityTypeConfiguration<ActionPermissonModel>
    {
        public void Configure(EntityTypeBuilder<ActionPermissonModel> builder)
        {
            builder.HasKey(p=>p.ActionPermissionId);
            builder.Property(p => p.ActionPermissionId).HasMaxLength(50);
            builder.Property(p => p.ActionNo).HasMaxLength(50);
            builder.Property(p => p.ActionName).HasMaxLength(50);
            builder.Property(p => p.ModuleNo).HasMaxLength(50);
            builder.Property(p => p.ModuleName).HasMaxLength(50);
            builder.Property(p => p.SystemNo).HasMaxLength(50);
            builder.Property(p => p.SystemName).HasMaxLength(50);
        }

        public void ConfigureRelationShip(EntityTypeBuilder<ActionPermissonModel> builder)
        {
            builder.HasMany(p => p.Roles).WithOne(p => p.Permission).HasForeignKey(p => p.PermissionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Users).WithOne(p => p.Permission).HasForeignKey(p => p.PermissionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
