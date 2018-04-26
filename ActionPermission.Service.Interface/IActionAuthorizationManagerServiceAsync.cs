using ActionPermission.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActionPermission.Services.Interface
{
    public interface IActionAuthorizationManagerServiceAsync
    {
        ICollection<ActionPermissonModel> GetActionPermissonLists(string userId);
        Task<ICollection<ActionPermissonModel>> GetActionPermissonListsAsync(string userId);
    }
}
