using ActionPermission.Domain;
using ActionPermission.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
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
using ActionPermission.Services.Interface;
using ActionPermission.Domain.Options;
using System.Security.Claims;

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
        private readonly IActionAuthorizationService authorizationServices;
        private readonly ILogger logger;
        private readonly ActionPermissionOptions permissionOptions;
        public ActionPermissionFilter(IOptions<SystemNoOptions> options, IOptions<ActionPermissionOptions> permissionOptions,IHostingEnvironment hostingEnvironment, IActionAuthorizationService authorizationServices,ILoggerFactory loggerFactory)
        {
            this.options = options.Value;
            this.hostingEnvironment = hostingEnvironment;
            this.authorizationServices = authorizationServices;
            this.permissionOptions = permissionOptions?.Value ?? new ActionPermissionOptions();
            logger = loggerFactory.CreateLogger<ActionPermissionFilter>();
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (permissionOptions.AnonymousPathList.Any(p => p == context.HttpContext.Request.Path))
            {
                return;
            }
            if(!context.HttpContext.User.Identity.IsAuthenticated)
            {
                await OnUnAuthorizationAsync(context);
                return;
            }
            await AuthorizationCore(context);
        }

        public async Task AuthorizationCore(AuthorizationFilterContext context)
        {
            string SystemNo, ModuleNo, ActionNo;
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var systemNoAttribute = descriptor.ControllerTypeInfo.GetCustomAttribute<SystemNoAttribute>();
            if(systemNoAttribute == null)
            {
                SystemNo = options?.SystemNo ?? hostingEnvironment.ApplicationName;
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
            var userId = context.HttpContext.User.Identity.Name;
            var roleId = context.HttpContext.User.Claims.Where(p => p.Type == ClaimTypes.Role).FirstOrDefault()?.Value;
            var action = new ActionPermissonModel(SystemNo, ModuleNo, ActionNo);
            try
            {
                bool hasPermission = await authorizationServices.HasPermissionAsync(userId, roleId, action);
                if (hasPermission)
                {
                    logger.LogInformation(action.ToString());
                    return;
                }
                else
                {
                    await OnUnAuthorizationAsync(context);
                    logger.LogInformation(action.ToString());
                    return;
                }
            }
            catch
            {
                throw;
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
