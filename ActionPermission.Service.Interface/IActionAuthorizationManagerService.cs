using ActionPermission.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActionPermission.Services.Interface
{
    public interface IActionAuthorizationManagerService
    {
        ICollection<ActionPermissonModel> GetActionPermissonLists(string userId);
        Task<ICollection<ActionPermissonModel>> GetActionPermissonListsAsync(string userId);
        void ActionRegister(ActionPermissonModel action);
        Task ActionRegisterAsync(ActionPermissonModel action);
        void SaveChange();
        Task SaveChangeAsync();
    }
}
