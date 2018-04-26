using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ActionPermission.Domain
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class ActionPermissionUser
    {
        public ActionPermissionUser()
        {
            Permissions = new List<UserPermission>();
            Roles = new List<RoleUser>();
        }
        public ActionPermissionUser(string userName,string email,string phoneNumber,string password):this()
        {
            UserId = Guid.NewGuid().ToString();
            UserName = UserName;
            PhoneNumber = phoneNumber;
            Password = password;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;

        }
        public void AddRole(ActionPermissionRole role)
        {
            var roleMap = new RoleUser(role.RoleId, UserId);
            Roles.Add(roleMap);
        }

        public void AddPermission(string permissionId)
        {
            var permission = new UserPermission(UserId, permissionId);
            Permissions.Add(permission);
        }
        public string UserId { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Password { get; protected set; }
        public DateTime? CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public virtual ICollection<UserPermission> Permissions { get; protected set; }
        public virtual ICollection<RoleUser> Roles { get; protected set; }

    }
}
