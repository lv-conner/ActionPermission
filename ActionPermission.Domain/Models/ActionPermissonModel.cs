using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class ActionPermissonModel
    {
        public ActionPermissonModel(string systemNameOrNo,string moduleNameOrNo,string actionNameOrNo)
            :this(systemNameOrNo,systemNameOrNo,moduleNameOrNo,moduleNameOrNo,actionNameOrNo,actionNameOrNo)
        {

        }
        public ActionPermissonModel(string systemName,string systemNo,string moduleName,string moduleNo,string actionName,string actionNo)
        {
            SystemName = systemName;
            ModuleName = moduleName;
            ActionName = actionName;
            SystemNo = systemNo;
            ModuleNo = moduleNo;
            ActionNo = actionNo;
        }
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
    }
}
