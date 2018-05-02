using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ActionPermission.Context;
using ActionPermission.Domain;
using ActionPermission.IRepository;
using ActionPermission.Repository;
using ActionPermission.Services;
using ActionPermission.Services.Interface;
using ActionPermission;
using ActionPermission.Domain.Options;
using ActionPermission.Helper;

namespace ActionPermissionWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options=>
            {
                options.Filters.AddService(typeof(ActionPermissionFilter));
            });
            //配置连接字符串
            services.AddDbContext<ActionPermissionContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSection("ActionPermissionConnectionString").Value.ToString());
                options.EnableSensitiveDataLogging(true);
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IActionAuthorizationRepository, ActionAuthorizationRepository>();
            services.AddScoped<IActionAuthorizationService, ActionAuthorizationService>();
            services.AddScoped<IActionAuthorizationManagerService, ActionAuthorizationManagerService>();
            services.AddAuthentication("actionPermission").AddCookie("actionPermission", options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            });
            services.AddScoped(typeof(ActionPermissionFilter));
            services.Configure<ActionPermissionOptions>(options =>
            {
                options.Admin = "Tim";
                options.AnonymousActionList.Add(new ActionPermissonModel("ActionPermission", "Account", "Login"));
                options.AnonymousActionList.Add(new ActionPermissonModel("ActionPermission", "Account", "Logout"));
                options.AnonymousPathList.Add("/Account/Login");
                options.AnonymousPathList.Add("/Account/Logout");
            });
            services.Configure<SystemNoOptions>(options =>
            {
                options.SystemNo = "ActionPermission";
            });
            //ActionPermissionHelper.RegisterAction(services.BuildServiceProvider().GetService<IActionAuthorizationManagerService>(), "ActionPermission");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
