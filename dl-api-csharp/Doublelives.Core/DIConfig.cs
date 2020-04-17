using Doublelives.Cos;
using Doublelives.Infrastructure.Cache;
using Doublelives.Persistence;
using Doublelives.Service.Pictures;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        }

        private static void ConfigureQueries(IServiceCollection services, IConfiguration configuration)
        {
        }

        private static void ConfigurePersistence(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AlbumDbContext>(
                options =>
                {
                    options
                        .UseMySql(
                            configuration.GetConnectionString("dl"),
                            it =>
                            {
                                it.MigrationsAssembly("Doublelives.Migrations");
                                it.ServerVersion("8.0.17-mysql");
                                it.EnableRetryOnFailure();
                            });
                },
                ServiceLifetime.Transient);
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