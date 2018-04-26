using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ActionPermission.Domain;

namespace ActionPermission.IRepository
{
    public interface IActionAuthorizationRepository:IRepository<ActionPermissonModel>
    {
        bool Find(string userId , string roleId, ActionPermissonModel action);
        Task<bool> FindAsync(string userId, string roleId,ActionPermissonModel action);
    }
}
