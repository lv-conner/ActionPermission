using ActionPermission.Context;
using ActionPermission.Domain;
using ActionPermission.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace ActionPermission.Repository
{
    public class ActionAuthorizationRepository : Repository<ActionPermissonModel>, IActionAuthorizationRepository
    {
        public ActionAuthorizationRepository(ActionPermissionContext context):base(context)
        {

        }
        
        public bool Find(string userId,string roleId, ActionPermissonModel action)
        {
            return Set.Any(p => p.Roles.Any(t => t.RoleId == roleId && t.PermissionId == action.ActionPermissionId) || p.Users.Any(t => t.UserId == userId && t.PermissionId == action.ActionPermissionId));
        }

        public async Task<bool> FindAsync(string userId, string roleId, ActionPermissonModel action)
        {
            return await Set.AnyAsync(p => p.Roles.Any(t => t.RoleId == roleId && t.PermissionId == action.ActionPermissionId) || p.Users.Any(t => t.UserId == userId && t.PermissionId == action.ActionPermissionId));
        }
    }
}
