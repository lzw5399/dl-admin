using COSXML;
using COSXML.Auth;
using Doublelives.Cos;
using Doublelives.Persistence;
using Doublelives.Service.Pictures;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Doublelives.Shared.ConfigModels;

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
            services.AddTransient<ITencentCosService, TencentCosService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IUserService, UserService>();
        }

        private static void ConfigurePersistence(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AlbumDbContext>(
                options =>
                {
                    options
                    .UseMySql(
                        configuration.GetConnectionString("album"),
                        it => it.MigrationsAssembly("Doublelives.Migrations"));
                },
                ServiceLifetime.Transient);
            services
                .AddTransient<IAlbumDbContext, AlbumDbContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigureDistributedCache(IServiceCollection services, IConfiguration configuration)
        {
            var csredis = new CSRedis.CSRedisClient(configuration["cache:redisconn"]);
            services.AddSingleton<IDistributedCache>(new CSRedisCache(csredis);
        }

        private static void ConfigureWorkContext(IServiceCollection services)
        {
            services.AddSingleton<IWorkContextAccessor, WorkContextAccessor>();
        }
    }
}
