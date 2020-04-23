using Doublelives.Infrastructure.Cache;
using Doublelives.Persistence;
using Doublelives.Service.Depts;
using Doublelives.Service.Menus;
using Doublelives.Service.Notices;
using Doublelives.Service.Pictures;
using Doublelives.Service.TencentCos;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Doublelives.Core
{
    public static class DIConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureServices(services, configuration);
            ConfigureQueries(services, configuration);
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
        }

        private static void ConfigureQueries(IServiceCollection services, IConfiguration configuration)
        {
        }

        private static void ConfigurePersistence(IServiceCollection services, IConfiguration configuration)
        {
            var conn = SqliteConn(configuration.GetConnectionString("dl"));
            services.AddDbContext<DlAdminDbContext>(
                options =>
                {
                    options
                        .UseSqlite(conn,
                            it =>
                            {
                                it.MigrationsAssembly("Doublelives.Migrations");
                            });
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static string SqliteConn(string originConn)
        {
            var builder = new SqliteConnectionStringBuilder(originConn);
            builder.DataSource = Path.Combine(AppContext.BaseDirectory, "SqliteDatabase", builder.DataSource);

            return builder.ToString();
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