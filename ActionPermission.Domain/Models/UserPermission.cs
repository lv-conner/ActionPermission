using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class UserPermission:BaseModel
    {
        public UserPermission()
        {

        }
        public UserPermission(string userId,string permissionId)
        {
            UserId = userId;
            PermissionId = permissionId;
        }
        public void Active()
        {
            IsEnable = true;
        }
        public string UserPermissionId { get; protected set; }
        public virtual ActionPermissionUser User { get; protected set; }
        public string UserId { get; protected set; }
        public string PermissionId { get; protected set; }
        public ActionPermissonModel Permission { get; protected set; }
        public bool IsEnable { get; protected set; }

    }
}
