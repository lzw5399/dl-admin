using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Doublelives.Api.AutoMapper;
using Doublelives.Api.Middlewares;
using Doublelives.Api.Swagger;
using Doublelives.Core;
using Doublelives.Core.Filters;
using Doublelives.Shared.ConfigModels;
using Doublelives.Shared.Constants;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace Doublelives.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            DIConfig.Configure(services, Configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "doublelives admin", Version = "v1.0"});

                // 主页右上角显示Authorize的图标
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = ApiHeaders.TOKEN,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "请输入token"
                });

                // 下面这个filter实现了c.AddSecurityRequirement的功能
                // 并且实现了 忽略给AllowAnonymousAttribute方法显示锁
                c.OperationFilter<AuthOperationFilter>();

                // 包含api项目的comment
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "swagger.xml"));
                // 如果需要包含其他项目的comment，在具体项目的PropertyGroup下添加如下
                //<GenerateDocumentationFile>true</GenerateDocumentationFile>
                //<NoWarn>$(NoWarn);1591</NoWarn>
                // 然后配置c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "项目的名称"));
            });

            services.Configure<TencentCosOptions>(Configuration.GetSection("tencentCos"));
            services.Configure<JwtOptions>(Configuration.GetSection("jwt"));
            services.Configure<CacheOptions>(Configuration.GetSection("cache"));

            services.AddAutoMapper(c => { c.AddProfile(new ViewModelProfile()); }, typeof(Startup));

            // services.AddCors(options => options.AddPolicy("AllowCORS", builder =>
            // {
            //     builder.AllowAnyMethod()
            //         .AllowAnyHeader()
            //         .AllowCredentials()
            //         .SetPreflightMaxAge(TimeSpan.FromSeconds(1728000))
            //         .WithOrigins(Configuration["cors:httpOrigin"], Configuration["cors:httpsOrigin"], "http://admin.doublelives.cn");
            // }));

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var key = Encoding.UTF8.GetBytes(Configuration["jwt:key"]);
                    options.TokenValidationParameters.ValidateIssuer = true;
                    options.TokenValidationParameters.ValidateAudience = true;
                    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(key);
                    options.TokenValidationParameters.ValidAudience = Configuration["jwt:audience"];
                    options.TokenValidationParameters.ValidIssuer = Configuration["jwt:issuer"];
                    options.TokenValidationParameters.NameClaimType = JwtClaimTypes.Name;
                    options.TokenValidationParameters.RoleClaimType = JwtClaimTypes.Role;
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = it =>
                        {
                            if (!string.IsNullOrEmpty(it.HttpContext.Request.Headers[ApiHeaders.TOKEN]))
                            {
                                it.Token = it.HttpContext.Request.Headers[ApiHeaders.TOKEN];
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            services
                .AddControllers(options => { options.Filters.Add(typeof(GlobalExceptionFilter)); })
                .AddNewtonsoftJson(options =>
                {
                    // 配置string转enum
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    // 避免循环依赖
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    // 配置序列化时时间格式
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseCors("AllowCORS");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<WorkContextMiddleware>();

            loggerFactory
                .AddSentry(options =>
                {
                    options.Dsn = Configuration["sentryClientKey"];
                    options.Environment = env.EnvironmentName;
                    options.MinimumEventLevel = LogLevel.Error;
                    options.Debug = env.IsDevelopment();
                });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "dl admin");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}