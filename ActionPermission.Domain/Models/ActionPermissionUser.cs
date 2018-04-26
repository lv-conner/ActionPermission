using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class ActionPermissionUser
    {
        public string UserId { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Password { get; protected set; }
        public DateTime? CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public ActionPermissionRole Role { get; protected set; }
        public ActionPermissonModel Permission { get; protected set; }
        public string PermissionId { get; protected set; }
        public string RoleId { get; protected set; }
        public List<ActionPermissonModel> Rules { get; protected set; }
        public List<ActionPermissionRole> Roles { get; protected set; }

    }
}
