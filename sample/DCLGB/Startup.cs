using System;
using System.Linq;
using System.Threading.Tasks;
using Ding;
using Ding.Dependency;
using Ding.Logs.Extensions;
using Ding.Schedulers.Quartz;
using Ding.Webs.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ding.Caches.EasyCaching;
using EasyCaching.InMemory;
using Ding.Locks.Default;
using Ding.Datas.Ef;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Ding.Events.Default;
using Ding.Utils.Config;
using DCLGB.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.HttpOverrides;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.Versioning;
using DCLGB.SwaggerExtensions;
using System.Collections.Generic;
using Ding.Swashbuckle.Filters.Operations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Models;
using IdentityModel;
using IdentityServer4.Test;
using System.Security.Claims;
using DCLGB.OAuths;
using DCLGB.SignalR;

namespace DCLGB
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="configuration">配置</param>
        /// <param name="env">环境变量</param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            ConfigFileHelper.Set(env: env);
            Configuration = configuration;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加Mvc服务
            services.AddMvc(options => {
                //options.Filters.Add( new AutoValidateAntiforgeryTokenAttribute() );
            }).AddControllersAsServices()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //添加NLog日志操作
            services.AddNLog();

            //添加EasyCaching缓存
            services.AddCache(options => options.UseInMemory());

            //添加业务锁
            services.AddLock();

            //注册XSRF令牌服务
            services.AddCsrfToken();

            //添加EF工作单元
            switch (Configuration["Data:Provider"])
            {
                case "MSSQL2012":
                    //====== 支持Sql Server 2012+ ==========
                    services.AddUnitOfWork<ILGBUnitOfWork, Data.SqlServer.LGBUnitOfWork>(Configuration.GetConnectionString("DefaultConnection"), config => config.SqlQuery.IsClearAfterExecution = true);
                    break;

                case "MSSQL2005":
                    //======= 支持Sql Server 2005+ ==========
                    services.AddUnitOfWork<ILGBUnitOfWork, Data.SqlServer.LGBUnitOfWork>(builder =>
                    {
                        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), option => option.UseRowNumberForPaging());
                    });
                    break;

                case "MySQL":
                    //======= 支持MySql =======
                    services.AddUnitOfWork<ILGBUnitOfWork, Data.MySql.LGBUnitOfWork>(Configuration.GetConnectionString("MySqlConnection"), Configuration);
                    break;

                case "PostgreSQL":
                default:
                    //======= 支持PgSql =======
                    services.AddUnitOfWork<ILGBUnitOfWork, Data.PgSql.LGBUnitOfWork>(Configuration.GetConnectionString("PgSqlConnection"), Configuration);
                    break;
            }

            //支持API多版本
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader(), new HeaderApiVersionReader()
                {
                    HeaderNames = { "api-version" }
                });
            });

            //添加Swagger
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info { Version = "v1", Title = "LiGongBang API", Description = "理工邦管理系统", Contact = new Contact() { Name = "丁川", Email = "100538511@qq.com", Url = "http://www.y-s.cc" } } );
                options.SwaggerDoc("v2", new Info { Version = "v2", Title = "LiGongBang API", Description = "理工邦管理系统", Contact = new Contact() { Name = "丁川", Email = "100538511@qq.com", Url = "http://www.y-s.cc" } });

                options.DocumentFilter<SetVersionInPaths>();
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });

                options.OperationFilter<AddRequestHeaderOperationFilter>();
                options.OperationFilter<AddResponseHeadersOperationFilter>();
                options.OperationFilter<AddFileParameterOperationFilter>();

                // 授权组合
                options.OperationFilter<AddSecurityRequirementsOperationFilter>();
                options.OperationFilter<AddAppendAuthorizeToSummaryOperationFilter>();
                
                options.AddSecurityDefinition("oauth2", new ApiKeyScheme()
                {
                    Description = "Token令牌(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",  
                    In = "header",
                    Name = "Authorization", // jwt默认的参数名称
                    Type = "apiKey",
                });
            });
            services.ConfigureSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Ding.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Ding.Webs.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DCLGB.xml"));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.Authority = SiteSetting.Current.Url;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = SiteSetting.Current.Url,
                        ValidateAudience = false,
                        ValidAudience = "Admin",
                        ValidateLifetime = true
                    };
                });

            ConfigureIdentityServer4(services);

            // 添加Razor静态Html生成器
            services.AddRazorHtml();

            //添加事件总线
            services.AddEventBus();

            //添加Cap事件总线
            //services.AddEventBus( options => {
            //    options.UseDashboard();
            //    options.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ) );
            //    options.UseRabbitMQ( "192.168.244.138" );
            //} );

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddSignalR();  // 注册SignalR
            services.AddConnections();

            services.AddTimedJob(); //注册定时任务

            //添加Ding基础设施服务
            return services.AddDing();
        }

        /// <summary>
        /// 配置开发环境请求管道
        /// </summary>
        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseResponseCompression();
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });
            var SwaggerRoutePrefix = "help";  //Swagger相对于根目录的目录
            app.UseSwaggerUI(config =>
            {
                config.IndexStream = () =>
                    GetType().GetTypeInfo().Assembly.GetManifestResourceStream("DCLGB.Swagger.index.html");
                config.RoutePrefix = SwaggerRoutePrefix;
                config.ShowExtensions();
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "LiGongBang API v1");
                config.SwaggerEndpoint("/swagger/v2/swagger.json", "LiGongBang API v2");
                config.DisplayOperationId();
            });

            CommonConfig(app);
        }

        /// <summary>
        /// 配置生产环境请求管道
        /// </summary>
        public void ConfigureProduction(IApplicationBuilder app)
        {
            app.UseResponseCompression();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseHttpsRedirection();
            CommonConfig(app);
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void CommonConfig(IApplicationBuilder app)
        {
            #region 解决Ubuntu Nginx 代理不能获取IP问题
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            #endregion

            app.UseErrorLog();
            app.UseStaticFiles();
            app.UseIdentityServer();// 启用 IdentityServer4 服务
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatsHub>("/chathub");
            });
            app.UseCsrfToken();
            ConfigRoute(app);

            app.UseTimedJob();
            Bootstrapper.Run();
            Run().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 路由配置,支持区域
        /// </summary>
        private void ConfigRoute(IApplicationBuilder app)
        {
            app.UseMvc(routes => {
                routes.MapRoute("areaRoute", "view/{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("api", "{controller}/{id?}");
            });
        }

        /// <summary>
        /// 运行调度器
        /// </summary>
        private static async Task Run()
        {
            var scheduler = new Scheduler();

            //扫描添加任务
            await scheduler.ScanJobsAsync();

            //启动调度器
            await scheduler.StartAsync();
        }

        /// <summary>
        /// 配置 IdentityServer4 服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public void ConfigureIdentityServer4(IServiceCollection services)
        {
            // AddIdentityServer：方法在依赖注入系统中注册IdentityServer，它还会注册一个基于内存存储的运行时状态，这对于开发场景非常有用，对于生产环境，您需要一个持久化或共享存储。https://identityserver4.readthedocs.io/en/release/quickstarts/8_entity_framework.html#refentityframeworkquickstart
            // AddDeveloperSigningCredential：在每次启动时，为令牌签名创建一个临时密钥。在生产环境需要一个持久化的密钥。https://identityserver4.readthedocs.io/en/release/topics/crypto.html#refcrypto
            // AddInMemoryApiResources：使用内存存储API资源。
            // AddInMemoryClients：使用内存存储密钥以及客户端
            // AddTestUsers：添加测试用户，用于自定义用户登录
            services.AddAuthentication().AddCookie("dummy");
            services.AddIdentityServer(options => options.Authentication.CookieAuthenticationScheme = "dummy")
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(GetApiResources())
                .AddInMemoryClients(GetClients())
                .AddTestUsers(GetUsers())
                .AddProfileService<CustomProfileService>()
                .AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();
        }

        /// <summary>
        /// 获取Api资源列表，作用域列表
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("Admin", "管理员", new List<string>(){JwtClaimTypes.Role}),
                new ApiResource("Customer", "客户"),
                new ApiResource("EveryOne", "匿名")
            };
        }

        /// <summary>
        /// 获取客户端列表，用于限制客户端访问作用域
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                // 客户端认证方式
                new Client()
                {
                    ClientId = "ding.admin",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // 用于认证的密码
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    // 客户端有权访问的作用域范围
                    AllowedScopes = {"Admin","Customer","EveryOne"}
                },
                new Client()
                {
                    ClientId = "ding.customer",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"Customer","EveryOne"}
                },
                new Client()
                {
                    ClientId = "ding.everyone",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"EveryOne"}
                },
                // 密码认证方式
                new Client()
                {
                    ClientId = "ding.ro.admin",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,// 启用刷新Token
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "Admin", "Customer", "EveryOne"}
                }
            };
        }

        /// <summary>
        /// 获取测试用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "admin",
                    Password = "123456",
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Email, "jianxuanbing@126.com")
                    }
                },
                new TestUser()
                {
                    SubjectId = "2",
                    Username = "test",
                    Password = "123456",
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.Role, "customer"),
                        new Claim(JwtClaimTypes.Email, "test@126.com")
                    }
                }
            };
        }

    }
}
