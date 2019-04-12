using DCLGB.Auth;
using DCLGB.Data;
using DCLGB.SignalR;
using DCLGB.SwaggerExtensions;
using Ding;
using Ding.Biz.OAuthLogin.Extensions;
using Ding.Caches.EasyCaching;
using Ding.CookieManager;
using Ding.Datas.Ef;
using Ding.Dependency;
using Ding.Events.Default;
using Ding.Locks.Default;
using Ding.Logs.Extensions;
using Ding.MailKit.Extensions;
using Ding.Net.Mail.Smtp;
using Ding.Schedulers.Quartz;
using Ding.Sms.FengHuo;
using Ding.Swashbuckle.Filters.Operations;
using Ding.Utils.Config;
using Ding.Webs.Extensions;
using Ding.Webs.Filters;
using EasyCaching.InMemory;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Senparc.CO2NET;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.RegisterServices;
using Senparc.Weixin.TenPay;
using Senparc.Weixin.WxOpen;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
                //options.Filters.Add(new ValidationAttribute() { AllowNulls = true });
                options.Filters.Add<ValidationAttribute>(); // 全局检查是否允许传入的值为空, true为如?id=&id1=或者空的实体这样的方式传入空值时不做检测并允许传入，否则如果当id没有值时，只能传入?id1=Url不能有id=  
                options.Filters.Add<ResultHandlerAttribute>(); // 对返回的结果进行全局处理
                options.ValueProviderFactories.Add(new JQueryQueryStringValueProviderFactory()); //处理数组接收中[]括号不识别问题
            }).AddJsonOptions(options => {
                // 解决json序列化时的循环引用问题,设置为不处理循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // 对 JSON 数据使用混合大小写。跟属性名同样的大小.输出
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                // 设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                // 实现所有非ASCII和控制字符(例如换行符)都被转义
                options.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
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
                    services.AddUnitOfWork<ILGBUnitOfWork, Data.SqlServer.LGBUnitOfWork>(Configuration.GetConnectionString("DefaultConnection"), Configuration);
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
            ConfigSwagger(services);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
            {
                o.LoginPath = new PathString("/Account/Login");
                o.AccessDeniedPath = new PathString("/Error/Forbidden");
            })
            .AddCookie(H5AuthorizeAttribute.H5AuthenticationScheme, o =>
            {
                o.LoginPath = new PathString("/Mobile/Login");
                o.AccessDeniedPath = new PathString("/Error/Forbidden");
            });

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

            services.AddTimedJob(); //注册定时任务

            services.AddMemoryCache();//使用本地缓存必须添加
            services.AddSession();

            services.AddLogin(x =>
            {
                x.QqOptions.APPID = SiteSetting.Current.Login.QQ.APPID;
                x.QqOptions.APPKey = SiteSetting.Current.Login.QQ.APPKey;
                x.QqOptions.Redirect_Uri = SiteSetting.Current.Login.QQ.Redirect_Uri;
                x.WeChatOptions.APPID = SiteSetting.Current.Login.WeChat.APPID;
                x.WeChatOptions.APPKey = SiteSetting.Current.Login.WeChat.APPKey;
                x.WeChatOptions.Redirect_Uri = SiteSetting.Current.Login.WeChat.Redirect_Uri;
            });

            //注册Cookie服务
            services.AddCookieManager(options =>
            {
                options.AllowEncryption = false;  //允许Cookie数据默认加密
                options.ThrowForPartialCookies = true;  //如果不是所有的 cookie 块在重新组装请求中都可用, 则抛出。
                options.ChunkSize = null;  //如果不允许在块中偏离，则设置为null
                options.DefaultExpireTimeInDays = 1;  //如果过期时间设置为空的 cookie，则默认 cookie 过期时间为1天
            });

            // 注册邮件
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.EmailConfig = new Ding.Net.Mail.Configs.EmailConfig()
                {
                    Host = SiteSetting.Current.Email.Host,
                    Port = SiteSetting.Current.Email.Port,
                    DisplayName = SiteSetting.Current.Email.FromName,
                    FromAddress = SiteSetting.Current.Email.From,
                    UserName = SiteSetting.Current.Email.UserName,
                    Password = SiteSetting.Current.Email.Password,
                    EnableSsl = SiteSetting.Current.Email.IsSSL
                };
                optionBuilder.MailKitConfig = new Ding.MailKit.Configs.MailKitConfig();
            });

            // 烽火短信
            services.AddFengHuoSms(o =>
            {
                o.SmsConfig.Name = SiteSetting.Current.Sms.FengHuoName;
                o.SmsConfig.PassWrod = SiteSetting.Current.Sms.FengHuoPassWord;
            });

            services.AddSenparcGlobalServices(Configuration)//Senparc.CO2NET 全局注册
                    .AddSenparcWeixinServices(Configuration);//Senparc.Weixin 注册

            //添加Ding基础设施服务
            return services.AddDing();
        }

        /// <summary>
        /// 配置开发环境请求管道
        /// </summary>
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
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

            CommonConfig(app, env, senparcSetting, senparcWeixinSetting);
        }

        /// <summary>
        /// 配置生产环境请求管道
        /// </summary>
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            app.UseResponseCompression();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseHttpsRedirection();
            CommonConfig(app, env, senparcSetting, senparcWeixinSetting);
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void CommonConfig(IApplicationBuilder app, IHostingEnvironment env, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            #region 解决Ubuntu Nginx 代理不能获取IP问题
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            #endregion

            app.UseEnableRequestRewind();
            app.UseErrorLog();
            app.UseStaticFiles();
			app.UseStaticHttpContext();
            app.UseSession();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatsHub>("/chathub");
            });
            app.UseCsrfToken();

            // Cookie策略设置
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Lax
            });

            ConfigRoute(app);

            #region 微信相关配置
            // 启动 CO2NET 全局注册，必须！
            IRegisterService register = RegisterService.Start(env, senparcSetting.Value)
                                                        .UseSenparcGlobal();

            #region 注册日志（按需，建议）

            register.RegisterTraceLog(ConfigTraceLog);//配置TraceLog

            #endregion

            //开始注册微信信息，必须！
            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value)
                //注意：上一行没有 ; 下面可接着写 .RegisterXX()

            #region 注册公众号或小程序（按需）

                //注册公众号（可注册多个）                                                -- DPBMARK MP
                .RegisterMpAccount(senparcWeixinSetting.Value, "【盛派网络小助手】公众号")// DPBMARK_END


                //注册多个公众号或小程序（可注册多个）                                        -- DPBMARK MiniProgram
                .RegisterWxOpenAccount(senparcWeixinSetting.Value, "【盛派网络小助手】小程序")// DPBMARK_END

                //除此以外，仍然可以在程序任意地方注册公众号或小程序：
                //AccessTokenContainer.Register(appId, appSecret, name);//命名空间：Senparc.Weixin.MP.Containers
            #endregion

            #region 注册微信支付（按需）        -- DPBMARK TenPay

                //注册旧微信支付版本（V2）（可注册多个）
                .RegisterTenpayOld(senparcWeixinSetting.Value, "【盛派网络小助手】公众号")//这里的 name 和第一个 RegisterMpAccount() 中的一致，会被记录到同一个 SenparcWeixinSettingItem 对象中

                //注册最新微信支付版本（V3）（可注册多个）
                .RegisterTenpayV3(senparcWeixinSetting.Value, "【盛派网络小助手】公众号")//记录到同一个 SenparcWeixinSettingItem 对象中

            #endregion             
            ;

            #endregion

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
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
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
        /// 配置Swagger
        /// </summary>
        /// <param name="services"></param>
        public void ConfigSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info { Version = "v1", Title = "LiGongBang API", Description = "理工邦管理系统", Contact = new Contact() { Name = "丁川", Email = "100538511@qq.com", Url = "http://www.y-s.cc" } });
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
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DCLGB.xml"), true);  // 第二个参数是Controller的注释，默认为false
            });
        }

        /// <summary>
        /// 配置微信跟踪日志
        /// </summary>
        private void ConfigTraceLog()
        {
            //这里设为Debug状态时，/App_Data/WeixinTraceLog/目录下会生成日志文件记录所有的API请求日志，正式发布版本建议关闭

            //如果全局的IsDebug（Senparc.CO2NET.Config.IsDebug）为false，此处可以单独设置true，否则自动为true
            Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog("系统日志", "系统启动");//只在Senparc.Weixin.Config.IsDebug = true的情况下生效

            //全局自定义日志记录回调
            Senparc.CO2NET.Trace.SenparcTrace.OnLogFunc = () =>
            {
                //加入每次触发Log后需要执行的代码
            };

            //当发生基于WeixinException的异常时触发
            WeixinTrace.OnWeixinExceptionFunc = ex =>
            {
                //加入每次触发WeixinExceptionLog后需要执行的代码

                ////发送模板消息给管理员                             -- DPBMARK Redis
                //var eventService = new Senparc.Weixin.MP.Sample.CommonService.EventService();
                //eventService.ConfigOnWeixinExceptionFunc(ex);      // DPBMARK_END
            };
        }
    }
}
