using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ActionPermission
{
    public class UnauthorizationJsonResult : JsonResult
    {
        public UnauthorizationJsonResult(object value) : base(value)
        {

        }
        public override void ExecuteResult(ActionContext context)
        {
            base.ExecuteResult(context);
        }
        public override Task ExecuteResultAsync(ActionContext context)
        {
            return base.ExecuteResultAsync(context);
        }
    }
}