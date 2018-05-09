using ActionPermission.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using ActionPermission.Domain;
using System.Linq;
using Microsoft.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    public class ActionPermissionContextTest
    {
        [Fact]
        public void AddAction()
        {


            using(var context = GetDbContext())
            {
                var action = new ActionPermissonModel("Pms", "Home", "Index");
                context.Set<ActionPermissonModel>().Add(action);
                Assert.True(context.SaveChanges() == 1);
            }
        }
        [Fact]
        public void AddRole()
        {
            using (var context = GetDbContext())
            {
                var role = new ActionPermissionRole("Admin");
                context.Set<ActionPermissionRole>().Add(role);
                var action = context.Set<ActionPermissonModel>().First();
                role.AddPermisson(action.ActionPermissionId);
                Assert.True(context.SaveChanges() > 0);
            }
        }
        [Fact]
        public void AddUser()
        {
            using (var context = GetDbContext())
            {
                var role = context.Set<ActionPermissionRole>().First();
                Assert.NotNull(role);
                var user = context.Set<ActionPermissionUser>().First();
                user.AddRole(role);
                context.Set<ActionPermissionUser>().Update(user);
                Assert.True(context.SaveChanges() > 0);
            }
        }

        [Fact]
        public void AddUserPermission()
        {
            using (var context = GetDbContext())
            {
                var user = context.Set<ActionPermissionUser>().First();
                var action = context.Set<ActionPermissonModel>().First();
                Assert.NotNull(action);
                user.AddPermission(action.ActionPermissionId);
                context.Set<ActionPermissionUser>().Update(user);
                Assert.True(context.SaveChanges() > 0);
            }
        }

        [Fact]
        public void LoadRealtion()
        {
            using (var context = GetDbContext())
            {
                var user = context.Set<ActionPermissionUser>().Include(p => p.Permissions).First();
                Assert.True(user.Permissions != null);
                Assert.True(user.Permissions.Count > 0);
            }
        }

        [Fact]
        public void CheckPermisson()
        {
            using (var context = GetDbContext())
            {
                var hasPermission = context.Set<ActionPermissonModel>().Any(p => p.Roles.Any(t=>t.PermissionId == "Pms_Home_Home" && t.RoleId=="roleId") || p.Users.Any(t=>t.PermissionId== "Pms_Home_Home" && t.UserId== "bd6020c3-7d9f-4e96-a4b7-efe0cfd4977b"));
            }
        }


        public DbContext GetDbContext()
        {
            IServiceProvider serviceProvider = new ServiceCollection().AddDbContext<ActionPermissionContext>(options =>
            {
                options.UseSqlServer("Server=PRCNMG1L0311;Initial catalog=ActionPermissionContext;user id=sa;password=Root@admin");
            }).BuildServiceProvider();
            return serviceProvider.GetService<ActionPermissionContext>();
        }
    }
}
