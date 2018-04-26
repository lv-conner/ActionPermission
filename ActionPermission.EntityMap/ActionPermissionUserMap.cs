using ActionPermission.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.EntityMap
{
    public class ActionPermissionUserMap : IEntityTypeConfiguration<ActionPermissionUser>
    {
        public void Configure(EntityTypeBuilder<ActionPermissionUser> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.UserId).HasMaxLength(50);
            builder.Property(p => p.UserName).HasMaxLength(50).IsUnicode();
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.Password).HasMaxLength(200);
            ConfigureRelationShip(builder);
        }

        public void ConfigureRelationShip(EntityTypeBuilder<ActionPermissionUser> builder)
        {
            builder.HasMany(p => p.Roles).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Permissions).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
