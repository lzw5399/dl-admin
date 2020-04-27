using Doublelives.Infrastructure.Cache;
using Doublelives.Persistence;
using Doublelives.Service.Depts;
using Doublelives.Service.Menus;
using Doublelives.Service.Notices;
using Doublelives.Service.Pictures;
using Doublelives.Service.Roles;
using Doublelives.Service.TencentCos;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.IO;

namespace Doublelives.Core
{
    public static class DIConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureServices(services, configuration);
            ConfigurePersistence(services, configuration);
            ConfigureDistributedCache(services, configuration);
            ConfigureWorkContext(services);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITencentCosService, TencentCosService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<INoticeService, NoticeService>();
            services.AddScoped<IDeptService, DeptService>();
            services.AddScoped<IRoleService, RoleService>();
        }

        private static void ConfigurePersistence(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DlAdminDbContext>(
                options =>
                {
                    options
                        .UseMySql(configuration.GetConnectionString("dl"),
                            it =>
                            {
                                it.MigrationsAssembly("Doublelives.Migrations");
                                it.ServerVersion(new ServerVersion(new Version(8, 0, 19), ServerType.MySql));
                            });
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigureDistributedCache(IServiceCollection services, IConfiguration configuration)
        {
            var csredis = new CSRedis.CSRedisClient(configuration["cache:redisconn"]);
            services.AddSingleton<IDistributedCache>(new CSRedisCache(csredis));
            services.AddSingleton<ICacheManager, CacheManager>();
        }

        private static void ConfigureWorkContext(IServiceCollection services)
        {
            services.AddSingleton<IWorkContextAccessor, WorkContextAccessor>();
        }
    }
}