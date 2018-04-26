using ActionPermission.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.EntityMap
{
    public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasKey(p => p.UserPermissionId);
            builder.Property(p => p.UserPermissionId).HasMaxLength(50);
        }
    }
}
