using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class ActionPermissionRole
    {
        public ActionPermissionRole()
        {
            Rules = new List<RolePermission>();
            Members = new List<RoleUser>();
        }
        public ActionPermissionRole(string roleName):this()
        {
            RoleId = Guid.NewGuid().ToString();
            RoleName = roleName;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
        public void UpdateRole(string roleName)
        {
            RoleName = roleName;
        }
        public void AddUser(string userId)
        {
            var roleUserMap = new RoleUser(RoleId, userId);
            Members.Add(roleUserMap);
        }

        public void AddPermisson(string permissionId)
        {
            var rule =new RolePermission(RoleId, permissionId);
            Rules.Add(rule);
        }
        public string RoleId { get; protected set; }
        public string RoleName { get; protected set; }
        public virtual ICollection<RolePermission> Rules { get; protected set; }
        public virtual ICollection<RoleUser> Members { get; protected set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
