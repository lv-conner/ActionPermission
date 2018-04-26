using ActionPermission.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain.Options
{
    public class ActionPermissionOptions
    {
        public List<ActionPermissonModel> AnonymousActionList { get; set; }
        public string Admin { get; set; }
    }
}
