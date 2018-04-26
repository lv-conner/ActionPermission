using ActionPermission.Services.Interface;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ActionPermission.IRepository;
using ActionPermission.Services;
using ActionPermission.Repository;
using ActionPermission.Context;
using ActionPermission.Domain;

namespace Service.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestServiceCreate()
        {
            IServiceProvider serviceProvider = GetServiceProvider();
            var services = serviceProvider.GetService<IActionAuthorizationService>();
            Assert.NotNull(services);
        }

        [Fact]
        public void TestAdd()
        {
            IServiceProvider serviceProvider = GetServiceProvider();
            var services = serviceProvider.GetService<IActionAuthorizationService>();
            var action = new ActionPermissonModel("Pms", "Home", "Index");
            Assert.False(services.HasPermission("tim", "admin", action));
        }

        public IServiceProvider GetServiceProvider()
        {
            return new ServiceCollection().AddDbContext<ActionPermissionContext>(options =>
            {
                options.UseSqlServer("Server=PRCNMG1L0311;Initial catalog=ActionPermissionContext;user id=sa;password=Root@admin");
            })
            .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
            .AddSingleton<IActionAuthorizationRepository, ActionAuthorizationRepository>()
            .AddSingleton<IActionAuthorizationService, ActionAuthorizationService>()
            .BuildServiceProvider();
        }
    }
}
