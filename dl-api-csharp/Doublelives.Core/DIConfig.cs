using CSRedis;
using Doublelives.Persistence;
using Doublelives.Service.Cache;
using Doublelives.Service.Cfgs;
using Doublelives.Service.Depts;
using Doublelives.Service.Dicts;
using Doublelives.Service.Menus;
using Doublelives.Service.Notices;
using Doublelives.Service.Pictures;
using Doublelives.Service.Roles;
using Doublelives.Service.Tasks;
using Doublelives.Service.TencentCos;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IDictService, DictService>();
            services.AddScoped<ICfgService, CfgService>();
        }

        private static void ConfigurePersistence(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DlAdminDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("dl"),
                            it =>
                            {
                                it.MigrationsAssembly("Doublelives.Migrations");
                                it.EnableRetryOnFailure();
                            });
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigureDistributedCache(IServiceCollection services, IConfiguration configuration)
        {
            var csredis = new CSRedisClient(configuration["cache:redisconn"]);
            services.AddSingleton(csredis);
            services.AddSingleton<ICacheManager, CacheManager>();
        }

        private static void ConfigureWorkContext(IServiceCollection services)
        {
            services.AddSingleton<IWorkContextAccessor, WorkContextAccessor>();
        }
    }
}