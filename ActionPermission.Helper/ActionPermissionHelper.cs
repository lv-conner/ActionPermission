using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ActionPermission.Domain;
using ActionPermission;
using ActionPermission.Services.Interface;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ActionPermission
{
    public static class ActionPermissionHelper
    {
        public static void RegisterAction(IActionAuthorizationManagerService service,string systemName)
        {
            if(string.IsNullOrEmpty(systemName))
            {
                throw new ArgumentNullException("systemName can not be null");
            }
            var asm = Assembly.GetEntryAssembly();
            var controllers = asm.GetTypes().Where(p => typeof(Controller).IsAssignableFrom(p)).ToList();
            foreach (var controller in controllers)
            {
                foreach (var action in GetActionPermisson(controller.GetCustomAttribute<SystemNoAttribute>()?.SystemNo ?? systemName, controller.GetCustomAttribute<ModuleNoAttribute>()?.ModuleNo ?? controller.Name, controller))
                {
                    service.ActionRegister(action);
                }
            }
            service.SaveChange();
        }

        public static IEnumerable<ActionPermissonModel> GetActionPermisson(string systemName,string moduleName,Type type)
        {
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(p=>p.ReturnType == typeof(IActionResult) || p.ReturnType == typeof(Task<IActionResult>)).ToList();
            foreach (var me in methods)
            {
                yield return new ActionPermissonModel(systemName, moduleName, me.GetCustomAttribute<ActionNoAttribute>()?.ActionNo??me.Name);
            }
        }
    }
}
