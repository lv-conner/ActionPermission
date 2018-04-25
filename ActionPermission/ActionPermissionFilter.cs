using ActionPermission.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ActionPermission
{
    //Authorization Filter
    /// <summary>
    /// 授权过滤器
    /// </summary>
    public class ActionPermissionFilter : IAsyncAuthorizationFilter
    {
        private readonly SystemNoOptions options;
        private readonly IHostingEnvironment hostingEnvironment;
        public ActionPermissionFilter(IOptions<SystemNoOptions> options,IHostingEnvironment hostingEnvironment)
        {
            this.options = options.Value;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if(!context.HttpContext.User.Identity.IsAuthenticated)
            {
               await OnUnAuthorizationAsync(context);
               return;
            }
            

        }

        public async Task AuthorizationCore(AuthorizationFilterContext context)
        {
            string SystemNo, ModuleNo, ActionNo;
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var systemNoAttribute = descriptor.ControllerTypeInfo.GetCustomAttribute<SystemNoAttribute>();
            if(systemNoAttribute == null)
            {
                SystemNo = hostingEnvironment.ApplicationName;
            }
            else
            {
                SystemNo = systemNoAttribute.SystemNo;
            }
            var moduleNoAttribute = descriptor.ControllerTypeInfo.GetCustomAttribute<ModuleNoAttribute>();
            if(moduleNoAttribute == null)
            {
                ModuleNo = descriptor.ControllerName;
            }
            else
            {
                ModuleNo = descriptor.ControllerName;
            }
            var actionNoAttribute = descriptor.MethodInfo.GetCustomAttribute<ActionNoAttribute>();
            if(actionNoAttribute == null)
            {
                ActionNo = descriptor.ActionName;
            }
            else
            {
                ActionNo = actionNoAttribute.ActionNo;
            }
        }

        public async Task OnUnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers["X-Requested-With"].FirstOrDefault() != null && context.HttpContext.Request.Headers["X-Requested-With"].ToString() == ("xmlhttprequest"))
            {
                context.Result = new UnauthorizationJsonResult(new { code = "401", message = "No Authencation" });
            }
            else
            {
                //!!important ChanllengeResult will send chanllenge to login path and add redirect url to query parameter
                context.Result = new ChallengeResult();
                //await context.HttpContext.ChallengeAsync();
                //context.Result = new ChallengeResult("/Login/Login");
            }
            await Task.CompletedTask;
        }
    }
}
