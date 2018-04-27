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
            var permission = Set.Include(p => p.Roles).Include(p => p.Users).First(p=>p.ActionPermissionId == action.ActionPermissionId);

            if (permission.Users.FirstOrDefault(p=>p.UserId == userId) != null || permission.Roles.FirstOrDefault(p => p.PermissionId == action.ActionPermissionId && p.RoleId == roleId) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> FindAsync(string userId, string roleId, ActionPermissonModel action)
        {
            var permission = await Set.Include(p => p.Roles).Include(p => p.Users).FirstOrDefaultAsync(p => p.ActionPermissionId == action.ActionPermissionId);
            if(permission == null)
            {
                return false;
            }
            if (permission.Users.First(p => p.UserId == userId) != null || permission.Roles.First(p => p.PermissionId == action.ActionPermissionId && p.RoleId == roleId) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
