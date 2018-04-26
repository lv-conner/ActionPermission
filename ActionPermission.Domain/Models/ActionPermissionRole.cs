using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class ActionPermissionRole
    {
        public string RoleId { get; protected set; }
        public string RoleName { get; protected set; }
        public virtual ICollection<ActionPermissonModel> Rules { get; protected set; }
        public virtual ICollection<ActionPermissionUser> Users { get; protected set; }
        public virtual ActionPermissionUser User { get; protected set; }
        public string UserId { get; protected set; }
        public virtual ActionPermissonModel Permission { get; protected set; }
        public string PermissionId { get; protected set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ActionPermissionRole()
        {
            Rules = new List<ActionPermissonModel>();
            Users = new List<ActionPermissionUser>();
        }
    }
}
