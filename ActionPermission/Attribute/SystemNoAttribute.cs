using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited =false)]
    public class SystemNoAttribute:Attribute
    {
        public string SystemNo { get; private set; }
        public SystemNoAttribute(string systemNo)
        {
            SystemNo = systemNo;
        }
    }
}
