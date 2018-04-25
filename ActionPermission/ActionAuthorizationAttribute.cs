using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionPermission
{
    public class ActionAuthorizationAttribute : Attribute, IFilterFactory
    {
        public ActionAuthorizationAttribute()
        {

        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ActionPermissionFilter>();
        }
    }
}
