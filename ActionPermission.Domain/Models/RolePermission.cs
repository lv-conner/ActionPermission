using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class RolePermission
    {
        public RolePermission()
        {

        }
        public RolePermission(string roleId,string permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
        public void Active()
        {
            IsEnable = true;
        }
        public string RolePermissonId { get; protected set; }
        public virtual ActionPermissonModel Permission { get; protected set; }
        public string PermissionId { get; protected set; }
        public virtual ActionPermissionRole Role { get; set; }
        public string RoleId { get; protected set; }
        public DateTime? CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public bool IsEnable { get; protected set; }
        public string CreateUserId { get; set; }

    }
}
