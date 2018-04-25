using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false,Inherited = false)]
    public class ActionNoAttribute:Attribute
    {
        public string ActionNo { get; private set; }
        public ActionNoAttribute(string actionNo)
        {
            ActionNo = actionNo;
        }
    }
}
