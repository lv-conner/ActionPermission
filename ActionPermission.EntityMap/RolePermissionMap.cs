using ActionPermission.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.EntityMap
{
    public class RolePermissionMap : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(p => p.RolePermissonId);
            builder.Property(p => p.RolePermissonId).HasMaxLength(50);
        }
    }
}
