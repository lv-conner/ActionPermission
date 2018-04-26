using ActionPermission.IRepository;
using ActionPermission.Domain;
using ActionPermission.Services.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ActionPermission.Domain.Options;

namespace ActionPermission.Services
{
    public class ActionAuthorizationService
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
            if(authorizationRepository == null)
            {
                throw new ArgumentNullException("IActionAuthorizationRepository can not be null");
            }
            this.authorizationRepository = authorizationRepository;
        }
        public virtual bool HasPermission(string userId, ActionPermissonModel action)
        {
            if(IsAdminOrAnonymousAction(userId, action))
            {
                return true;
            }
            return authorizationRepository.Find(userId, action);
        }

        public virtual async Task<bool> HasPermissionAsync(string userId, ActionPermissonModel action)
        {
            if (IsAdminOrAnonymousAction(userId, action))
            {
                return true;
            }
            return await authorizationRepository.FindAsync(userId, action);
        }

        private bool IsAdminOrAnonymousAction(string userId,ActionPermissonModel action)
        {
            bool result = false;
            if (userId == null)
            {
                throw new ArgumentNullException("user Id can not null");
            }
            if (options.Admin == userId || options.AnonymousActionList.Contains(action))
            {
                result = true;
            }
            return result;
        }
    }
}
