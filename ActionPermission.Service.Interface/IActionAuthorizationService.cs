using ActionPermission.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActionPermission.Services.Interface
{
    public interface IActionAuthorizationService
    {
        bool HasPermission(string userId,string roleId, ActionPermissonModel action);
        Task<bool> HasPermissionAsync(string userId, string roleId, ActionPermissonModel action);

    }
}
