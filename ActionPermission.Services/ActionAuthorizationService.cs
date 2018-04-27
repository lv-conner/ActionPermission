using ActionPermission.IRepository;
using ActionPermission.Domain;
using ActionPermission.Services.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ActionPermission.Domain.Options;
using System.Linq;

namespace ActionPermission.Services
{
    public class ActionAuthorizationService: IActionAuthorizationService
    {
        private readonly IActionAuthorizationRepository authorizationRepository;
        private readonly ActionPermissionOptions options;
        public ActionAuthorizationService(IActionAuthorizationRepository authorizationRepository,IOptions<ActionPermissionOptions> options)
        {
            this.options = options?.Value;
            if(this.options==null)
            {
                this.options = new ActionPermissionOptions();
            }
            this.authorizationRepository = authorizationRepository ?? throw new ArgumentNullException("IActionAuthorizationRepository can not be null");
        }
        public virtual bool HasPermission(string userId,string roleId, ActionPermissonModel action)
        {
            if(IsAdminOrAnonymousAction(userId,action))
            {
                return true;
            }
            if(roleId == null)
            {
                roleId = "";
            }
            return authorizationRepository.Find(userId, roleId, action);
        }

        public virtual async Task<bool> HasPermissionAsync(string userId,string roleId, ActionPermissonModel action)
        {
            if (IsAdminOrAnonymousAction(userId, action))
            {
                return true;
            }
            return await authorizationRepository.FindAsync(userId, roleId, action);
        }

        private bool IsAdminOrAnonymousAction(string userId,ActionPermissonModel action)
        {
            bool result = false;
            if (userId == null)
            {
                result = false;
            }
            if (options.Admin == userId || options.AnonymousActionList.Any(p=>p.ActionPermissionId == action.ActionPermissionId))
            {
                result = true;
            }
            return result;
        }
    }
}
