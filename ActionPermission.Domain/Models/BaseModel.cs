using System;
using System.Collections.Generic;
using System.Text;

namespace ActionPermission.Domain
{
    public class BaseModel
    {
        public DateTime? CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
    }
}
