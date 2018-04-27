using ActionPermission.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain.Options
{
    public class ActionPermissionOptions
    {
        public ActionPermissionOptions()
        {
            AnonymousActionList = new List<ActionPermissonModel>();
            AnonymousPathList = new List<string>();
        }
        //匿名访问路径。
        public List<string> AnonymousPathList { get; protected set; }
        //匿名访问操作。
        public List<ActionPermissonModel> AnonymousActionList { get; protected set; }
        public string Admin { get; set; }
    }
}
