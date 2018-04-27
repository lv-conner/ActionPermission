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

        public void ActionRegister(ActionPermissonModel action)
        {
            authorizationRepository.Add(action);
        }

        public Task ActionRegisterAsync(ActionPermissonModel action)
        {
            return authorizationRepository.AddAsync(action);
        }

        public ICollection<ActionPermissonModel> GetActionPermissonLists(string userId)
        {
            return authorizationRepository.QueryList(p => true);
        }

        public async Task<ICollection<ActionPermissonModel>> GetActionPermissonListsAsync(string userId)
        {
            return await authorizationRepository.QueryListAsync(p=>true);
        }

        public void SaveChange()
        {
            authorizationRepository.SaveChange();
        }

        public Task SaveChangeAsync()
        {
            return authorizationRepository.SaveChangeAsync();
        }
    }
}
