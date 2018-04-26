using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class RoleUser: BaseModel
    {
        public RoleUser()
        {

        }
        public RoleUser(string roleId,string userId)
        {
            RoleUserId = Guid.NewGuid().ToString();
            RoleId = roleId;
            UserId = userId;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
        public string RoleUserId { get; set; }
        public string RoleId { get; protected set; }
        public string UserId { get; protected set; }
        public ActionPermissionRole Role { get; protected set; }
        public ActionPermissionUser User { get; protected set; }
    }
}
