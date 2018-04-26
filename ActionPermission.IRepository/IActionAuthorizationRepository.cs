using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ActionPermission.Domain;

namespace ActionPermission.IRepository
{
    public interface IActionAuthorizationRepository:IRepository<ActionPermissonModel>
    {
        bool Find(string userId, ActionPermissonModel action);
        Task<bool> FindAsync(string userId, ActionPermissonModel action);
    }
}
