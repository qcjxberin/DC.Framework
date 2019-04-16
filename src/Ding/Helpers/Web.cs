using Ding.Security.Principals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ding.Helpers {
    /// <summary>
    /// Web操作
    /// </summary>
    public static class Web {

        #region 静态构造方法

        /// <summary>
        /// 初始化Web操作
        /// </summary>
        static Web() {
            try {
                HttpContextAccessor = Ioc.Create<IHttpContextAccessor>();
                Environment = Ioc.Create<IHostingEnvironment>();
            }
            catch {
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        /// <summary>
        /// 当前Http上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextAccessor?.HttpContext;

        /// <summary>
        /// 当前Http请求
        /// </summary>
        public static HttpRequest Request => HttpContext?.Request;

        /// <summary>
        /// 当前Http响应
        /// </summary>
        public static HttpResponse Response => HttpContext?.Response;

        /// <summary>
        /// 宿主环境
        /// </summary>
        public static IHostingEnvironment Environment { get; set; }

        #endregion

        #region LocalIpAddress(本地IP)

        /// <summary>
        /// 本地IP
        /// </summary>
        public static string LocalIpAddress
        {
            get
            {
                try
                {
                    var ipAddress = HttpContext.Connection.LocalIpAddress;
                    return IPAddress.IsLoopback(ipAddress)
                        ? IPAddress.Loopback.ToString()
                        : ipAddress.MapToIPv4().ToString();
                }
                catch
                {
                    return IPAddress.Loopback.ToString();
                }
            }
        }

        #endregion

        #region RequestType(请求类型)

        /// <summary>
        /// 请求类型
        /// </summary>
        public static string RequestType => HttpContext?.Request?.Method;

        #endregion

        #region Form(表单)

        /// <summary>
        /// Form表单
        /// </summary>
        public static IFormCollection Form => HttpContext?.Request?.Form;

        #endregion

        #region User(当前用户安全主体)

        /// <summary>
        /// 当前用户安全主体
        /// </summary>
        public static ClaimsPrincipal User {
            get {
                if( HttpContext == null )
                    return UnauthenticatedPrincipal.Instance;
                if( HttpContext.User is ClaimsPrincipal principal )
                    return principal;
                return UnauthenticatedPrincipal.Instance;
            }
        }

        #endregion

        #region Identity(当前用户身份)

        /// <summary>
        /// 当前用户身份
        /// </summary>
        public static ClaimsIdentity Identity {
            get {
                if( User.Identity is ClaimsIdentity identity )
                    return identity;
                return UnauthenticatedIdentity.Instance;
            }
        }

        #endregion

        #region Body(请求正文)

        /// <summary>
        /// 请求正文
        /// </summary>
        public static string Body {
            get {
                Request.EnableRewind();
                return File.ToString( Request.Body, isCloseStream: false );
            }
        }

        #endregion

        #region GetBodyAsync(获取请求正文)

        /// <summary>
        /// 获取请求正文
        /// </summary>
        public static async Task<string> GetBodyAsync() {
            Request.EnableRewind();
            return await File.ToStringAsync( Request.Body, isCloseStream: false );
        }

        #endregion

        #region Client( Web客户端 )

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        public static Ding.Webs.Clients.WebClient Client() {
            return new Ding.Webs.Clients.WebClient();
        }

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        public static Ding.Webs.Clients.WebClient<TResult> Client<TResult>() where TResult : class {
            return new Ding.Webs.Clients.WebClient<TResult>();
        }

        #endregion

        #region Url(请求地址)

        /// <summary>
        /// 请求地址
        /// </summary>
        public static string Url => Request?.GetDisplayUrl();

        #endregion

        #region Ip(客户端Ip地址)

        /// <summary>
        /// Ip地址
        /// </summary>
        private static string _ip;

        /// <summary>
        /// 设置Ip地址
        /// </summary>
        /// <param name="ip">Ip地址</param>
        public static void SetIp( string ip ) {
            _ip = ip;
        }

        /// <summary>
        /// 重置Ip地址
        /// </summary>
        public static void ResetIp() {
            _ip = null;
        }

        /// <summary>
        /// 客户端Ip地址
        /// </summary>
        public static string Ip {
            get {
                if( string.IsNullOrWhiteSpace( _ip ) == false )
                    return _ip;
                var list = new[] { "127.0.0.1", "::1" };
                var result = HttpContext?.Connection?.RemoteIpAddress.SafeString();
                if( string.IsNullOrWhiteSpace( result ) || list.Contains( result ) )
                    result = GetLanIp();
                return result;
            }
        }

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        private static string GetLanIp() {
            foreach( var hostAddress in Dns.GetHostAddresses( Dns.GetHostName() ) ) {
                if( hostAddress.AddressFamily == AddressFamily.InterNetwork )
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        #endregion

        #region Host(主机)

        /// <summary>
        /// 主机
        /// </summary>
        public static string Host => HttpContext == null ? Dns.GetHostName() : GetClientHostName();

        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        private static string GetClientHostName() {
            var address = GetRemoteAddress();
            if( string.IsNullOrWhiteSpace( address ) )
                return Dns.GetHostName();
            var result = Dns.GetHostEntry( IPAddress.Parse( address ) ).HostName;
            if( result == "localhost.localdomain" )
                result = Dns.GetHostName();
            return result;
        }

        /// <summary>
        /// 获取远程地址
        /// </summary>
        private static string GetRemoteAddress() {
            return Request?.Headers["HTTP_X_FORWARDED_FOR"] ?? Request?.Headers["REMOTE_ADDR"];
        }

        #endregion

        #region Browser(浏览器)

        /// <summary>
        /// 浏览器
        /// </summary>
        public static string Browser => Request?.Headers["User-Agent"];

        #endregion

        #region RootPath(根路径)

        /// <summary>
        /// 根路径
        /// </summary>
        public static string RootPath => Environment?.ContentRootPath;

        #endregion 

        #region WebRootPath(Web根路径)

        /// <summary>
        /// Web根路径，即wwwroot
        /// </summary>
        public static string WebRootPath => Environment?.WebRootPath;

        #endregion 

        #region GetFiles(获取客户端文件集合)

        /// <summary>
        /// 获取客户端文件集合
        /// </summary>
        public static List<IFormFile> GetFiles() {
            var result = new List<IFormFile>();
            var files = Request.Form.Files;
            if( files == null || files.Count == 0 )
                return result;
            result.AddRange( files.Where( file => file?.Length > 0 ) );
            return result;
        }

        #endregion

        #region GetFile(获取客户端文件)

        /// <summary>
        /// 获取客户端文件
        /// </summary>
        public static IFormFile GetFile() {
            var files = GetFiles();
            return files.Count == 0 ? null : files[0];
        }

        #endregion

        #region UrlEncode(Url编码)

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(this string url, bool isUpper = false ) {
            return UrlEncode( url, Encoding.UTF8, isUpper );
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(this string url, string encoding, bool isUpper = false ) {
            encoding = string.IsNullOrWhiteSpace( encoding ) ? "UTF-8" : encoding;
            return UrlEncode( url, Encoding.GetEncoding( encoding ), isUpper );
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(this string url, Encoding encoding, bool isUpper = false ) {
            var result = HttpUtility.UrlEncode( url, encoding );
            if( isUpper == false )
                return result;
            return GetUpperEncode( result );
        }

        /// <summary>
        /// 获取大写编码字符串
        /// </summary>
        private static string GetUpperEncode( string encode ) {
            var result = new StringBuilder();
            int index = int.MinValue;
            for( int i = 0; i < encode.Length; i++ ) {
                string character = encode[i].ToString();
                if( character == "%" )
                    index = i;
                if( i - index == 1 || i - index == 2 )
                    character = character.ToUpper();
                result.Append( character );
            }
            return result.ToString();
        }

        #endregion

        #region UrlDecode(Url解码)

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="url">url</param>
        public static string UrlDecode(this string url ) {
            return HttpUtility.UrlDecode( url );
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        public static string UrlDecode(this string url, Encoding encoding ) {
            return HttpUtility.UrlDecode( url, encoding );
        }

        #endregion

        #region Write(输出文件)

        /// <summary>
        /// 输出文件
        /// </summary>
        /// <param name="stream">文件流</param>
        public static void Write(FileStream stream)
        {
            long size = stream.Length;
            byte[] buffer = new byte[size];
            stream.Read(buffer, 0, (int)size);
            stream.Dispose();
            System.IO.File.Delete(stream.Name);

            Response.ContentType = "application/octet-stream";
            Response.Headers.Add("Content-Disposition", "attachment;filename=" + WebUtility.UrlEncode(Path.GetFileName(stream.Name)));
            Response.Headers.Add("Content-Length", size.ToString());

            Task.Run(async () => { await Response.Body.WriteAsync(buffer, 0, (int)size); }).GetAwaiter().GetResult();
            Response.Body.Close();
        }

        #endregion

        #region Write(输出内容)

        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="text">内容</param>
        public static void Write(string text)
        {
            Response.ContentType = "text/plain;charset=utf-8";
            Task.Run(async () => { await Response.WriteAsync(text); }).GetAwaiter().GetResult();
        }

        #endregion

        #region Redirect(跳转到指定链接)

        /// <summary>
        /// 跳转到指定链接
        /// </summary>
        /// <param name="url">链接</param>
        public static void Redirect(string url) => Response?.Redirect(url);

        #endregion

        #region ContentType(内容类型)

        /// <summary>
        /// 内容类型
        /// </summary>
        public static string ContentType => HttpContext?.Request?.ContentType;

        #endregion

        #region QueryString(参数)

        /// <summary>
        /// 参数
        /// </summary>
        public static string QueryString => HttpContext?.Request?.QueryString.ToString();

        #endregion

        /// <summary>
        /// 返回绝对地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string AbsoluteUri(this HttpRequest request)
        {
            var absoluteUri = string.Concat(
                          request.Scheme,
                          "://",
                          request.Host.ToUriComponent(),
                          request.PathBase.ToUriComponent(),
                          request.Path.ToUriComponent(),
                          request.QueryString.ToUriComponent());

            return absoluteUri;
        }

        public enum AgentType
        {
            Android = 0,
            IPhone = 1,
            IPad = 2,
            WindowsPhone = 3,
            Windows = 4,
            Wechat = 6,
            MacOS = 7
        }

        /// <summary>
        /// 获取客户端信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static AgentType UserAgentType(this HttpRequest request)
        {
            var userAgent = request.Headers["User-Agent"].ToString();
            switch (userAgent)
            {
                case string android when android.Contains("MicroMessenger"):
                    return AgentType.Wechat;
                case string android when android.Contains("Android"):
                    return AgentType.Android;
                case string android when android.Contains("iPhone"):
                    return AgentType.IPhone;
                case string android when android.Contains("iPad"):
                    return AgentType.IPad;
                case string android when android.Contains("Windows Phone"):
                    return AgentType.WindowsPhone;
                case string android when android.Contains("Windows NT"):
                    return AgentType.Windows;
                case string android when android.Contains("Mac OS"):
                    return AgentType.MacOS;
            }
            return AgentType.Android;
        }

    }
}