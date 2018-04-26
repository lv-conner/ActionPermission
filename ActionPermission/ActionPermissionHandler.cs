using ActionPermission.Domain.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ActionPermission
{
    //AuthenticationHandler<ActionPermissionOptions>
    public class ActionPermissionHandler : IAuthenticationRequestHandler, IAuthenticationSignInHandler,
        IAuthenticationSignOutHandler
    {
        public ActionPermissionHandler(IOptionsMonitor<ActionPermissionOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        {
            
        }

        public Task<AuthenticateResult> AuthenticateAsync()
        {
            throw new NotImplementedException();
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当此处返回true时，HandleAuthenticateAsync将不会被执行
        /// </summary>
        /// <returns></returns>
        public Task<bool> HandleRequestAsync()
        {
            return Task.FromResult<bool>(false);
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当该模式为默认授权模式时，使用HttpContext.SignInAsync => IAuthenticationService.SignInAsync => SignInAsync
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="properties">认证</param>
        /// <returns></returns>
        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 当使用HttpContext.SignOutAsync并指定模式为此模式了 => IAuthenticationService.SignOutAsync 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task SignOutAsync(AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }
        ///// <summary>
        ///// 当此模式指定为默认模式，且没有IAuthenticationRequestHandler处理请求时，该方法会被调用处理认证请求
        ///// </summary>
        ///// <returns></returns>
        //protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
