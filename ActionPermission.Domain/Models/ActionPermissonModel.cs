using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class ActionPermissonModel
    {
        public ActionPermissonModel()
        {

        }
        public virtual ICollection<RolePermission> Roles { get; protected set; }
        public virtual ICollection<UserPermission> Users { get; protected set; }
        public ActionPermissonModel(string systemNameOrNo,string moduleNameOrNo,string actionNameOrNo)
            :this(systemNameOrNo,systemNameOrNo,moduleNameOrNo,moduleNameOrNo,actionNameOrNo,actionNameOrNo)
        {

        }
        public ActionPermissonModel(string systemName,string systemNo,string moduleName,string moduleNo,string actionName,string actionNo)
        {
            ActionPermissionId = Guid.NewGuid().ToString();
            SystemName = systemName;
            ModuleName = moduleName;
            ActionName = actionName;
            SystemNo = systemNo;
            ModuleNo = moduleNo;
            ActionNo = actionNo;
            ActionPermissionId = GeneratePermissionId();
            Roles = new List<RolePermission>();
            Users = new List<UserPermission>();
        }
        public string ActionPermissionId { get; protected set; }
        public string SystemName { get; protected set;}
        public string ModuleName { get; protected set; }
        public string ActionName { get; protected set; }
        public string SystemNo { get; protected set; }
        public string ModuleNo { get; protected set; }
        public string ActionNo { get; protected set; }
        public override string ToString()
        {
            return $"{"SystemNo:" + SystemNo + "\t" + "SystemName:" + SystemName + "\t" + "ModuleNo:" + ModuleNo + "\t" + "ModuleName:" + ModuleName + "\t" + "ActionNo" + ActionNo + "\t" + "ActionName:" + ActionName}";
        }
        private string GeneratePermissionId()
        {
            return string.Format("{0}_{1}_{2}", SystemNo, ModuleNo, ModuleName);
        }
    }
}
