using Ding.Biz.OAuthLogin;
using Ding.Xml;
using System.ComponentModel;

namespace DCLGB
{
    /// <summary>
    /// 站点参数设置
    /// </summary>
    [DisplayName("站点参数设置")]
    [XmlConfigFile("Config/Site.config", 15000)]
    public class SiteSetting : XmlConfig<SiteSetting>
    {
        /// <summary>网站域名</summary>
        [Description("网站域名")]
        public string Url { get; set; } = "http://localhost:9191";

        /// <summary>
        /// 第三方平台参数设置
        /// </summary>
        [Description("第三方平台参数设置")]
        public Login Login { get; set; } = new Login();

        /// <summary>
        /// 网站配置
        /// </summary>
        [Description("网站配置")]
        public WebConfig WebConfig { get; set; } = new WebConfig();

        /// <summary>
        /// 积分参数设置
        /// </summary>
        [Description("积分参数设置")]
        public Credit Credit { get; set; } = new Credit();

        /// <summary>
        /// Email配置
        /// </summary>
        [Description("Email配置")]
        public Email Email { get; set; } = new Email();

        /// <summary>
        /// 短信配置
        /// </summary>
        [Description("短信配置")]
        public Sms Sms { get; set; } = new Sms();

        /// <summary>
        /// 消息模板配置
        /// </summary>
        [Description("消息模板配置")]
        public Messages Messages { get; set; } = new Messages();
    }

    /// <summary>
    /// 登录参数设置
    /// </summary>
    [DisplayName("登录参数设置")]
    public class Login
    {
        public QQ QQ { get; set; } = new QQ();

        public WeChat WeChat { get; set; } = new WeChat();

        public GitHub GitHub { get; set; } = new GitHub();
    }

    /// <summary>
    /// QQ参数设置
    /// </summary>
    [DisplayName("QQ参数设置")]
    public class QQ : ConfigBase
    {
        /// <summary>
        /// 服务商
        /// </summary>
        public string Server { get; set; } = "qq";

        /// <summary>
        /// 用户名前缀
        /// </summary>
        public string UNamePrefix { get; set; } = "qq";
    }

    /// <summary>
    /// WeChat参数设置
    /// </summary>
    [DisplayName("WeChat参数设置")]

    public class WeChat : ConfigBase
    {
        /// <summary>
        /// 服务商
        /// </summary>
        public string Server { get; set; } = "weixin";

        /// <summary>
        /// 用户名前缀
        /// </summary>
        public string UNamePrefix { get; set; } = "wx";
    }

    /// <summary>
    /// GitHub参数设置
    /// </summary>
    [DisplayName("GitHub参数设置")]
    public class GitHub: ConfigBase
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName { get; set; } = "";
    }

    /// <summary>
    /// 积分设置
    /// </summary>
    [DisplayName("积分设置")]
    public class Credit
    {
        /// <summary>
        /// 支付积分名称
        /// </summary>
        public string PayCreditName { get; set; } = "金币";
        /// <summary>
        /// 支付积分价格(单位为100个)
        /// </summary>
        public int PayCreditPrice { get; set; } = 1;
        /// <summary>
        /// 每天最大发放支付积分
        /// </summary>
        public int DayMaxSendPayCredits { get; set; } = 2000;
        /// <summary>
        /// 每笔订单最大使用支付积分
        /// </summary>
        public int OrderMaxUsePayCredits { get; set; } = 200;
        /// <summary>
        /// 注册支付积分
        /// </summary>
        public int RegisterPayCredits { get; set; } = 2;
        /// <summary>
        /// 每天登陆支付积分
        /// </summary>
        public int LoginPayCredits { get; set; } = 2;
        /// <summary>
        /// 验证邮箱支付积分
        /// </summary>
        public int VerifyEmailPayCredits { get; set; } = 2;
        /// <summary>
        /// 验证手机支付积分
        /// </summary>
        public int VerifyMobilePayCredits { get; set; } = 2;
        /// <summary>
        /// 完善用户信息支付积分
        /// </summary>
        public int CompleteUserInfoPayCredits { get; set; } = 2;
        /// <summary>
        /// 完成订单支付积分(以订单金额的百分比计算)
        /// </summary>
        public int CompleteOrderPayCredits { get; set; } = 2;
        /// <summary>
        /// 评价商品支付积分
        /// </summary>
        public int ReviewProductPayCredits { get; set; } = 2;
        /// <summary>
        /// 等级积分名称
        /// </summary>
        public string RankCreditName { get; set; } = "成长值";
        /// <summary>
        /// 每天最大发放等级积分
        /// </summary>
        public int DayMaxSendRankCredits { get; set; } = 200;
        /// <summary>
        /// 注册等级积分
        /// </summary>
        public int RegisterRankCredits { get; set; } = 2;
        /// <summary>
        /// 每天登陆等级积分
        /// </summary>
        public int LoginRankCredits { get; set; } = 2;
        /// <summary>
        /// 验证邮箱等级积分
        /// </summary>
        public int VerifyEmailRankCredits { get; set; } = 2;
        /// <summary>
        /// 验证手机等级积分
        /// </summary>
        public int VerifyMobileRankCredits { get; set; } = 2;
        /// <summary>
        /// 完善用户信息等级积分
        /// </summary>
        public int CompleteUserInfoRankCredits { get; set; } = 2;
        /// <summary>
        /// 完成订单等级积分(以订单金额的百分比计算)
        /// </summary>
        public int CompleteOrderRankCredits { get; set; } = 50;
        /// <summary>
        /// 评价商品等级积分
        /// </summary>
        public int ReviewProductRankCredits { get; set; } = 2;
    }

    /// <summary>
    /// 网站配置
    /// </summary>
    [DisplayName("网站配置")]
    public class WebConfig
    {
        /// <summary>
        /// cookie的有效域
        /// </summary>
        public string CookieDomain { get; set; }
        /// <summary>
        /// 随机库
        /// </summary>
        public string RandomLibrary { get; set; } = "123456789abcdefghjkmnpqrstuvwxy";
        /// <summary>
        /// PC主题
        /// </summary>
        public string PCTheme { get; set; } = "ybbhlk";
        /// <summary>
        /// 移动版主题
        /// </summary>
        public string MobileTheme { get; set; } = "default";
        /// <summary>
        /// 图片cdn(不能以"/"结尾)
        /// </summary>
        public string ImageCDN { get; set; }
        /// <summary>
        /// csscdn(不能以"/"结尾)
        /// </summary>
        public string CSSCDN { get; set; }
        /// <summary>
        /// 脚本cdn(不能以"/"结尾)
        /// </summary>
        public string ScriptCDN { get; set; }
        /// <summary>
        /// 更新pv统计时间间隔(单位为分钟,0代表不统计pv)
        /// </summary>
        public int UpdatePVStatTimespan { get; set; } = 3;
        /// <summary>
        /// 更新用户在线时间间隔(单位为分钟,0代表不更新)
        /// </summary>
        public int UpdateOnlineTimeSpan { get; set; } = 2;
        /// <summary>
        /// 在线人数缓存时间(单位为分钟,0代表即时数量)
        /// </summary>
        public int OnlineCountExpire { get; set; } = 0;
        /// <summary>
        /// 在线用户过期时间(单位为分钟)
        /// </summary>
        public int OnlineUserExpire { get; set; } = 8;
        /// <summary>
        /// 最大在线人数
        /// </summary>
        public int MaxOnlineCount { get; set; } = 10000;
        /// <summary>
        /// 是否统计浏览器(0代表不统计，1代表统计)
        /// </summary>
        public int IsStatBrowser { get; set; } = 1;
        /// <summary>
        /// 是否统计操作系统(0代表不统计，1代表统计)
        /// </summary>
        public int IsStatOS { get; set; } = 1;
        /// <summary>
        /// 是否统计区域(0代表不统计，1代表统计)
        /// </summary>
        public int IsStatRegion { get; set; } = 1;
        /// <summary>
        /// 是否关闭商城(0代表打开，1代表关闭)
        /// </summary>
        public int IsClosed { get; set; } = 0;
        /// <summary>
        /// 是否允许游客使用购物车
        /// </summary>
        public int IsGuestSC { get; set; } = 1;
        /// <summary>
        /// 购物车的提交方式(0代表跳转到提示页面，1代表跳转到列表页面，2代表ajax提交)
        /// </summary>
        public int SCSubmitType { get; set; } = 0;
        /// <summary>
        /// 禁止访问时间
        /// </summary>
        public string BanAccessTime { get; set; }
        /// <summary>
        /// 禁止访问ip
        /// </summary>
        public string BanAccessIP { get; set; }
        /// <summary>
        /// 允许访问ip
        /// </summary>
        public string AllowAccessIP { get; set; }
        /// <summary>
        /// 后台允许访问ip
        /// </summary>
        public string AdminAllowAccessIP { get; set; }
        /// <summary>
        /// 登陆类型(1代表用户名登陆，2代表邮箱登陆，3代表手机登陆，空字符串代表不允许登陆)
        /// </summary>
        public string LoginType { get; set; } = "123";
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        public int LoginFailTimes { get; set; } = 0;
        /// <summary>
        /// 影子登录名
        /// </summary>
        public string ShadowName { get; set; } = "myname";
        /// <summary>
        /// 是否记住密码(0代表不记住，1代表记住)
        /// </summary>
        public int IsRemember { get; set; } = 1;
        /// <summary>
        /// 使用验证码的页面
        /// </summary>
        public string VerifyPages { get; set; } = "/account/register,/account/login";
        /// <summary>
        /// 注册类型(1代表用户名注册，2代表邮箱注册，3代表手机注册，空字符串代表不允许注册)
        /// </summary>
        public string RegType { get; set; } = "123";
        /// <summary>
        /// 注册时间间隔(单位为秒，0代表无限制)
        /// </summary>
        public int RegTimeSpan { get; set; } = 0;
        /// <summary>
        /// 保留用户名
        /// </summary>
        public string ReservedName { get; set; } = "admin";
        /// <summary>
        /// 忽略词
        /// </summary>
        public string IgnoreWords { get; set; }
        /// <summary>
        /// 禁止的邮箱提供者
        /// </summary>
        public string BanEmailProvider { get; set; }
        /// <summary>
        /// 允许的邮箱提供者
        /// </summary>
        public string AllowEmailProvider { get; set; }
        /// <summary>
        /// 是否发送欢迎信息(0代表不发送，1代表发送)
        /// </summary>
        public int IsWebcomeMsg { get; set; } = 1;
        /// <summary>
        /// 图片水印类型
        /// </summary>
        public int watermarktype { get; set; } = 0;
        /// <summary>
        /// 附件上传类型
        /// </summary>
        public string fileextension { get; set; } = "gif,jpg,png,bmp,rar,zip,doc,xls,txt";
        /// <summary>
        /// 视频上传类型
        /// </summary>
        public string videoextension { get; set; } = "flv,mp3,mp4,avi";
        /// <summary>
        /// 附件上传目录
        /// </summary>
        public string filepath { get; set; } = "upload";
        /// <summary>
        /// 附件保存方式
        /// </summary>
        public int filesave { get; set; } = 2;
        /// <summary>
        /// 文件上传大小
        /// </summary>
        public int attachsize { get; set; } = 51200;
        /// <summary>
        /// 图片上传大小
        /// </summary>
        public int imgsize { get; set; } = 10240;
        /// <summary>
        /// 视频上传大小
        /// </summary>
        public int videosize { get; set; } = 102400;
        /// <summary>
        /// 图片最大高度(像素)
        /// </summary>
        public int imgmaxheight { get; set; } = 0;
        /// <summary>
        /// 图片最大宽度(像素)
        /// </summary>
        public int imgmaxwidth { get; set; } = 800;
        /// <summary>
        /// 生成缩略图宽度(像素)
        /// </summary>
        public int thumbnailwidth { get; set; } = 300;
        /// <summary>
        /// 生成缩略图高度(像素)
        /// </summary>
        public int thumbnailheight { get; set; } = 300;
        /// <summary>
        /// 缩略图生成方式
        /// </summary>
        public string thumbnailmode { get; set; } = "Cut";
        /// <summary>
        /// 水印文字
        /// </summary>
        public string watermarktext { get; set; } = "海凌科电子";
        /// <summary>
        /// 图片水印位置
        /// </summary>
        public int watermarkposition { get; set; } = 9;
        /// <summary>
        /// 图片生成质量
        /// </summary>
        public int watermarkimgquality { get; set; } = 80;
        /// <summary>
        /// 文字字体
        /// </summary>
        public string watermarkfont { get; set; } = "Tahoma";
        /// <summary>
        /// 文字大小(像素)
        /// </summary>
        public int watermarkfontsize { get; set; } = 12;
        /// <summary>
        /// 图片水印文件
        /// </summary>
        public string watermarkpic { get; set; } = "watermark.png";
        /// <summary>
        /// 水印透明度
        /// </summary>
        public int watermarktransparency { get; set; } = 5;
        /// <summary>
        /// 网站名称
        /// </summary>
        public string webname { get; set; } = "我要开发板";
        /// <summary>
        /// 公司名称
        /// </summary>
        public string webcompany { get; set; } = "深圳市海凌科电子有限公司";
        /// <summary>
        /// 网站域名
        /// </summary>
        public string weburl { get; set; } = "http://xueyuan.hlktech.com";
        /// <summary>
        /// 网站安装目录
        /// </summary>
        public string webpath { get; set; } = "/";
    }

    /// <summary>
    /// Email配置
    /// </summary>
    [DisplayName("Email配置")]
    public class Email
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Host { get; set; } = "smtp.exmail.qq.com";
        /// <summary>
        /// 服务器端口
        /// </summary>
        public int Port { get; set; } = 465;
        /// <summary>
        /// 邮箱账号
        /// </summary>
        public string UserName { get; set; } = "@hlktech.com";
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string Password { get; set; } = "Hlktech";
        /// <summary>
        /// 发送邮箱
        /// </summary>
        public string From { get; set; } = "@hlktech.com";
        /// <summary>
        /// 发送邮箱的昵称
        /// </summary>
        public string FromName { get; set; } = "理工邦";
        /// <summary>
        /// 是否启用SSL,0为否,1为是
        /// </summary>
        public bool IsSSL { get; set; } = true;
    }

    /// <summary>
    /// 短信配置
    /// </summary>
    [DisplayName("短信配置")]
    public class Sms
    {
        /// <summary>
        /// 短信服务器地址
        /// </summary>
        public string Url { get; set; } = "http://gw.api.taobao.com/router/rest";
        /// <summary>
        /// 短信AccessKeyId
        /// </summary>
        public string AccessKeyId { get; set; } = "";
        /// <summary>
        /// 短信AccessKeySecret
        /// </summary>
        public string AccessKeySecret { get; set; } = "";
        /// <summary>
        /// 短信签名
        /// </summary>
        public string passKey { get; set; } = "理工邦";

        /// <summary>
        /// 注册欢迎短信模板
        /// </summary>
        public string RegisterWelComBody { get; set; } = "SMS_137580016";

        /// <summary>
        /// 烽火短信账号
        /// </summary>
        public string FengHuoName { get; set; } = "";

        /// <summary>
        /// 烽火短信密码
        /// </summary>
        public string FengHuoPassWord { get; set; } = "";
    }

    /// <summary>
    /// 消息模板配置
    /// </summary>
    [DisplayName("消息模板配置")]
    public class Messages
    {
        /// <summary>
        /// 找回密码内容
        /// </summary>
        public string FindPwdBody { get; set; } = "<p>{shopname}{siteurl}{username}{deadline}{url}</p>";
        /// <summary>
        /// 安全中心验证邮箱内容
        /// </summary>
        public string SCVerifyBody { get; set; } = "<p>{shopname}{siteurl}{username}{deadline}{url}</p>";
        /// <summary>
        /// 安全中心确认更新邮箱内容
        /// </summary>
        public string SCUpdateBody { get; set; } = "<p>{shopname}{siteurl}{username}{deadline}{url}</p>";
        /// <summary>
        /// 注册欢迎信息
        /// </summary>
        public string MailWebcomeBody { get; set; } = "<p>{shopname}<br />注册时间：{regtime}<br />注册邮箱：{email}</p>";
        /// <summary>
        /// 注册欢迎信息
        /// </summary>
        public string SmsWebcomeBody { get; set; } = "欢迎您注册{shopname} 注册时间：{regtime}";
    }
}
