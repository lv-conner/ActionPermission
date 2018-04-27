using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActionPermission
{
    public class PermissionRegisterMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostingEnvironment hostingEnvironment;
        public PermissionRegisterMiddleware(RequestDelegate next,IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.next = next;
        }
        public Task Invoke(HttpContext context)
        {
            return next(context);
        }
    }

    public static class PermissionRegisterMiddlewareExtension
    {
        public static IApplicationBuilder AddPermissionRegisterMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<PermissionRegisterMiddleware>();
            return builder;
        }
    }
}
