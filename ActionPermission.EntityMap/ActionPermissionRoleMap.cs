using ActionPermission.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.EntityMap
{
    public class ActionPermissionRoleMap : IEntityTypeConfiguration<ActionPermissionRole>
    {
        public void Configure(EntityTypeBuilder<ActionPermissionRole> builder)
        {
            builder.HasKey(p => p.RoleId);
            builder.Property(p => p.RoleId).HasMaxLength(50);
            ConfigureRelationShip(builder);
        }
        public void ConfigureRelationShip(EntityTypeBuilder<ActionPermissionRole> builder)
        {
            builder.HasMany(p => p.Users).WithOne(p => p.Role).HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Rules).WithOne(p => p.Role).HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
