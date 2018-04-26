using ActionPermission.Context;
using ActionPermission.Domain;
using ActionPermission.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActionPermission.Repository
{
    public class ActionAuthorizationRepository : Repository<ActionPermissonModel>, IActionAuthorizationRepository
    {
        public ActionAuthorizationRepository(ActionPermissionContext context):base(context)
        {

        }
        public bool Find(string userId, ActionPermissonModel action)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindAsync(string userId, ActionPermissonModel action)
        {
            throw new NotImplementedException();
        }
    }
}
