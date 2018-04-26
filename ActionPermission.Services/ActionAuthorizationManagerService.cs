using ActionPermission.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ActionPermission.IRepository;
using ActionPermission.Domain;
using System.Threading.Tasks;

namespace ActionPermission.Services
{
    public class ActionAuthorizationManagerService: IActionAuthorizationManagerService
    {
        private readonly IActionAuthorizationRepository authorizationRepository;
        public ActionAuthorizationManagerService(IActionAuthorizationRepository authorizationRepository)
        {
            this.authorizationRepository = authorizationRepository;
        }

        public ICollection<ActionPermissonModel> GetActionPermissonLists(string userId)
        {
            return authorizationRepository.QueryList(p => true);
        }

        public async Task<ICollection<ActionPermissonModel>> GetActionPermissonListsAsync(string userId)
        {
            return await authorizationRepository.QueryListAsync(p=>true);
        }
    }
}
