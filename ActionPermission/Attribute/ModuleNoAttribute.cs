using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false,Inherited =false)]
    public class ModuleNoAttribute:Attribute
    {
        public string ModuleNo { get; private set; }
        public ModuleNoAttribute(string moduleNo)
        {
            ModuleNo = moduleNo;
        }
    }
}
